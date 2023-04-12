using Kafka.Bus.Handlers;

namespace Kafka.Bus.Config
{
    public class KafkaConfig
    {
        public string BootstrapServers { get; set; }
        public string ConsumerGroupId { get; set; }
        public IList<IKafkaMessageHandler> MessageHandlers { get; set; } = new List<IKafkaMessageHandler>();
    }
}
