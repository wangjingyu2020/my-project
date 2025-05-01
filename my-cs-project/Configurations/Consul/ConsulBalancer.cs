using Consul;
using Microsoft.Extensions.Options;

namespace my_cs_project.Configurations.Consul
{
    /**
     * This class is for configuring load balancing for service-to-service communication 
     * within the Consul registry.
     */
    public class ConsulBalancer
    {

        public AgentService ChooseService(string serviceName)
        {
            var consulClient = new ConsulClient(c => c.Address = new Uri("http://consul:8500/"));
            var services = consulClient.Agent.Services().Result.Response;
            var targetServices = services.Where(c => c.Value.Service.Equals(serviceName)).Select(c => c.Value);
            if (targetServices.Count() == 0)
            {
                return null!;
            }
            var targetService = targetServices!.ElementAt(new Random().Next(1, 1000) % targetServices.Count());

            return targetService;
        }
    }
}
