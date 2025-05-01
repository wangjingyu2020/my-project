<?php
namespace App\Http\Controllers;

use App\Services\IAuthService;
use Illuminate\Http\Request;

class AuthController extends Controller
{
    private IAuthService $authService;

    public function __construct(IAuthService $authService)
    {
        $this->authService = $authService;
    }

    public function register(Request $request)
    {
        return $this->authService->register($request);
    }

    public function login(Request $request)
    {
        return $this->authService->login($request);
    }

    public function validateToken(Request $request)
    {
        return $this->authService->validateToken($request);
    }

    public function logout(Request $request)
    {
        return $this->authService->logout($request);
    }
}

