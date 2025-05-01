<?php
namespace App\Services;

use Illuminate\Http\Request;

interface IAuthService
{
    public function register(Request $request);
    public function login(Request $request);
    public function validateToken(Request $request);
    public function logout(Request $request);
}
