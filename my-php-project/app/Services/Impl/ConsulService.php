<?php

namespace App\Services\Impl;

use GuzzleHttp\Client;

class ConsulService
{
    protected $client;
    protected $consulUrl;

    public function __construct()
    {
        $this->client = new Client();
        $this->consulUrl = env('CONSUL_URL', 'http://127.0.0.1:8500');
    }

    public function registerService()
    {
        $serviceId = 'auth';
        $serviceData = [
            'ID' => $serviceId,
            'Name' => 'auth',
            'Address' => env('APP_HOST', '127.0.0.1'),
            'Port' => (int) env('APP_PORT', 8000),
        ];

        try {
            $this->client->put("{$this->consulUrl}/v1/agent/service/register", [
                'json' => $serviceData
            ]);
        } catch (\Exception $e) {
            logger()->error("Failed to register with Consul: " . $e->getMessage());
        }
    }
}
