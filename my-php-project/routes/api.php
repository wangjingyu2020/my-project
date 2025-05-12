<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\AuthController;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "api" middleware group. Make something great!
|
*/

Route::post('/auth/register', [AuthController::class, 'register']);

Route::post('/auth/login', [AuthController::class, 'login']);


route::post('/auth/validate', [AuthController::class, 'validateToken']);

Route::post('/auth/logout', [AuthController::class, 'logout']);

Route::get('/health', function () {
    return response()->json(['status' => 'UP']);
});

