using Confluent.Kafka;
using Microsoft.Extensions.Logging;

namespace AdvancedKafka.Shared.Config;

public class KafkaConsumer(IConsumer<Ignore, string> consumer, ILogger<KafkaConsumer> logger)
{
    public void ConsumeMessage(string topic, CancellationToken token)
    {
        consumer.Subscribe(topic);

        while (true)
        {
            try
            {
                var consumeResult = consumer.Consume(token);
                logger.LogInformation($"Consume message from {topic}: {consumeResult.Message.Value}");
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                return;
            }
        }
    }
}