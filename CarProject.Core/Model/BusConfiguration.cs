namespace CarProject.Core.Model
{
    public class BusConfiguration
    {
        public BusConfiguration()
        {
            DefaultRequestTimeoutTime = TimeSpan.FromSeconds(20);
        }

        public string RabbitMqUri { get; set; }
        public ushort RabbitMqPort { get; set; }
        public string RabbitMqUserName { get; set; }
        public string RabbitMqPassword { get; set; }
        public string RabbitMqClusterNodes { get; set; }
        public ushort PrefetchCount { get; set; }
        public TimeSpan DefaultRequestTimeoutTime { get; set; }
        public TimeSpan Heartbeat { get; set; }
    }

}
