using Confluent.Kafka;
using Kafka.Bus.Config;
using Kafka.Bus.Services.DataContracts;
using Microsoft.Extensions.Configuration;

namespace Kafka.Bus.Services
{
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaProducerService(IConfiguration configuration)
        {
            var kafkaConfig = configuration.GetSection("Kafka").Get<KafkaConfig>();

            var config = new ProducerConfig { BootstrapServers = kafkaConfig.BootstrapServers };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProduceAsync(string topic, string message)
        {
            await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
        }
    }
}
