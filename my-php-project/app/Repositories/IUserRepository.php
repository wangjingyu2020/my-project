<?php
namespace App\Repositories;


interface IUserRepository
{
public function createUser($name, $email, $password);
public function findByEmail($email);
public function findById($id);
}
