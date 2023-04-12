using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka.Bus.Services.DataContracts
{
    public interface IKafkaProducerService
    {
        Task ProduceAsync(string topic, string message);
    }
}
