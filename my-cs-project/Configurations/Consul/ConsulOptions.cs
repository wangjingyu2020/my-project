namespace my_cs_project.Configurations.Consul
{
    /**
     * Define an entity class for Consul configuration.
     */
    public class ConsulOptions
    {
        public string? IP { get; set; }
        public string? Port { get; set; }
        public string? ServiceName { get; set; }
        public string? ConsulHost { get; set; }
        public string? ConsulDataCenter { get; set; }
    }
}
