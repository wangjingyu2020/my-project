<?php
namespace App\Providers;
use App\Services\Impl\ConsulService;
use App\Services\IAuthService;
use App\Services\Impl\AuthService;
use App\Repositories\IUserRepository;
use App\Repositories\Impl\UserRepository;
use Illuminate\Support\ServiceProvider;
use App\Models\User;



class AppServiceProvider extends ServiceProvider
{
    /**
     * Register any application services.
     */
    public function register(): void
    {
        $this->app->bind(IAuthService::class, AuthService::class);
        $this->app->bind(IUserRepository::class, UserRepository::class);
        //
    }

    /**
     * Bootstrap any application services.
     */
    public function boot(): void
    {
        (new ConsulService())->registerService();

    }
}
