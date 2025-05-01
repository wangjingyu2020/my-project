using Consul;
using Microsoft.Extensions.Options;

namespace my_cs_project.Configurations.Consul
{
    /**
     * This class is for configuring Consul.
     */
    public static class ConsulRegistryExtensions
    {
        public static WebApplication UseConsulRegistry(this WebApplication webApplication, IHostApplicationLifetime lifetime)
        {
            // To retrieve the IP and Port for mindset detection.
            var ip = "portfolio";
            var port = "8090";
            // generate serviceId
            var serviceId = Guid.NewGuid().ToString();
            // Create a Consul client object.
            var consulClient = new ConsulClient(c =>
            {
                c.Address = new Uri("http://consul:8500/");
                c.Datacenter = "dc1";
            });
            // Register the service with Consul.
            consulClient.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = serviceId,
                Name = "portfolio", // key
                Address = ip,
                Port = Convert.ToInt32(port),
                Check = new AgentServiceCheck()
                {
                    Interval = TimeSpan.FromSeconds(12),
                    HTTP = $"http://{ip}:{port}/api/health",
                    Timeout = TimeSpan.FromSeconds(5),
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(20)
                }
            });

            // Deregister the instance.
            lifetime.ApplicationStopped.Register(async () =>
            {
                await consulClient.Agent.ServiceDeregister(serviceId);
            });

            return webApplication;
        }
    }
}
