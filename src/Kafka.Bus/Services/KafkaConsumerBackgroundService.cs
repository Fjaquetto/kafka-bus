using Kafka.Bus.Config;
using Kafka.Bus.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka.Bus.Services
{
    public class KafkaConsumerBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public KafkaConsumerBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) 
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var messageHandlers = scope.ServiceProvider.GetServices<IKafkaMessageHandler>();

            var tasks = messageHandlers.Select(handler => KafkaConsumerHostExtensions.StartConsumer(scope.ServiceProvider, handler.Topic, stoppingToken));//TODO: Change it to accept cancellationtoken

            await Task.WhenAll(tasks);
        }
    }
}
