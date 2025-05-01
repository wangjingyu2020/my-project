<?php

namespace Database\Seeders;

// use Illuminate\Database\Console\Seeds\WithoutModelEvents;
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
        // \App\Models\User::factory(10)->create();

        DB::table('users')->truncate();

         \App\Models\User::factory()->create([
             'name' => 'Jingyu',
             'email' => 'jyw19971118@gmail.com',
             'password' => Hash::make('123456'),
         ]);
    }
}
