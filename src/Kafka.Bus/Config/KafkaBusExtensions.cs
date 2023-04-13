using Kafka.Bus.Services;
using Kafka.Bus.Services.DataContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kafka.Bus.Config
{
    public static class KafkaBusExtensions
    {
        public static IServiceCollection AddKafkaLibrary(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<KafkaConfig>(serviceProvider =>
            {
                return configuration.GetSection("Kafka").Get<KafkaConfig>();
            });
            services.AddSingleton<IKafkaProducerService, KafkaProducerService>();
            services.AddSingleton<IKafkaConsumerService, KafkaConsumerService>();
            services.AddHostedService<KafkaConsumerBackgroundService>();

            return services;
        }
    }
}
