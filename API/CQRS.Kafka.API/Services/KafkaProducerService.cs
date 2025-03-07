using Confluent.Kafka;
using System.Text.Json;

namespace CQRS.Kafka.API.Services;

public class KafkaProducerService
{
    private readonly IProducer<string, string> _producer;

    public KafkaProducerService()
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
        _producer = new ProducerBuilder<string, string>(config).Build();
    }

    public async Task PublishEventAsync<T>(string topic, T @event)
    {
        var message = new Message<string, string>
        {
            Key = Guid.NewGuid().ToString(),
            Value = JsonSerializer.Serialize(@event)
        };

        await _producer.ProduceAsync(topic, message);
    }
}
