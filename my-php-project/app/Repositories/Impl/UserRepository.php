<?php
namespace App\Repositories\Impl;

use App\Repositories\IUserRepository;
use App\Models\User;

class UserRepository implements IUserRepository
{
public function createUser($name, $email, $password)
{
return User::create([
'name' => $name,
'email' => $email,
'password' => $password,
]);
}

public function findByEmail($email)
{
return User::where('email', $email)->first();
}

public function findById($id)
{
return User::find($id);
}
}
