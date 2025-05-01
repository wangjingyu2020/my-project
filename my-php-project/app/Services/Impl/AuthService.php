<?php

namespace App\Services\Impl;

use App\Repositories\IUserRepository;
use App\Repositories\UserRepository;
use Firebase\JWT\JWT;
use Firebase\JWT\Key;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Facades\Redis;
use Carbon\Carbon;
use Illuminate\Http\Request;
use App\Services\IAuthService;

class AuthService implements IAuthService
{
    private IUserRepository $userRepository;
    private $secretKey;

    public function __construct(IUserRepository $userRepository)
    {
        $this->userRepository = $userRepository;
        $this->secretKey = env('JWT_SECRET', 'your_default_secret_key');
    }

    public function register(Request $request)
    {
        $user = $this->userRepository->createUser($request->name, $request->email, Hash::make($request->password));

        return response()->json([
            'message' => 'User registered successfully!',
            'user' => $user
        ], 201);
    }

    public function login(Request $request)
    {
        $user = $this->userRepository->findByEmail($request->email);

        if (!$user || !Hash::check($request->password, $user->password)) {
            return response()->json(['message' => 'Invalid credentials'], 401);
        }

        $payload = [
            'sub' => $user->id,
            'email' => $user->email,
            'name' => $user->name,
            'iat' => Carbon::now()->timestamp,
            'exp' => Carbon::now()->addHours(1)->timestamp
        ];

        $token = JWT::encode($payload, $this->secretKey, 'HS256');

        Redis::set("auth_token:{$user->id}", $token);

        return response()->json([
            'status' => 'OK',
            'message' => 'Login successful',
            'token' => $token,
            'user' => $user,
        ]);
    }

    public function validateToken(Request $request)
    {
        try {
            $token = $request->input('token');
            $decoded = JWT::decode($token, new Key($this->secretKey, 'HS256'));

            $cachedToken = Redis::get("auth_token:{$decoded->sub}");
            if (!$cachedToken || $cachedToken !== $token) {
                return response()->json(['message' => 'Token invalid or expired', 'status' => '401'], 401);
            }

            return response()->json(['user' => $decoded]);
        } catch (\Exception $e) {
            return response()->json(['message' => 'Invalid token', 'status' => '401'], 401);
        }
    }

    public function logout(Request $request)
    {
        $token = $request->bearerToken();
        if (!$token) {
            return response()->json(['message' => 'Token missing', 'status' => '401'], 401);
        }

        try {
            $decoded = JWT::decode($token, new Key($this->secretKey, 'HS256'));

            Redis::del("auth_token:{$decoded->sub}");

            return response()->json(['message' => 'Logout successful']);
        } catch (\Exception $e) {
            return response()->json(['message' => 'Invalid token', 'status' => '401'], 401);
        }
    }
}

