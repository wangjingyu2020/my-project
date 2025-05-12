<?php

namespace Database\Seeders;

use App\Models\User;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     */
    public function run(): void
    {
        DB::table('users')->truncate();

         User::factory()->create([
             'name' => 'Jingyu',
             'email' => 'jyw19971118@gmail.com',
             'password' => Hash::make('123456'),
         ]);
    }
}
