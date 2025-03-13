using Confluent.Kafka;
using Microsoft.Extensions.Logging;

namespace AdvancedKafka.Shared.Config;

public class KafkaProducer(IProducer<Null, string> producer, ILogger<KafkaProducer> logger)
{
    public async Task<DeliveryResult<Null, string>> ProduceMessageAsync(string message, string topic)
    {
        try
        {
            var kafkaMessage = new Message<Null, string> { Value = message };
            var deliveryResult = await producer.ProduceAsync(topic, kafkaMessage);
            logger.LogInformation($"Produced message: {deliveryResult.Value}");
            return deliveryResult;
        }
        catch (Exception e)
        {
            logger.LogError($"Error producing message: {e.Message}");
            return new DeliveryResult<Null, string>();
        }
    }
}