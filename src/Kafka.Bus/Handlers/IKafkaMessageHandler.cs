namespace Kafka.Bus.Handlers
{
    public interface IKafkaMessageHandler
    {
        string Topic { get; }
        Task HandleMessageAsync(string message);
    }
}
