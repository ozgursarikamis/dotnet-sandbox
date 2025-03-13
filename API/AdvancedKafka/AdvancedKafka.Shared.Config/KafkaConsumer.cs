using Confluent.Kafka;
using Microsoft.Extensions.Logging;

namespace AdvancedKafka.Shared.Config;

public class KafkaConsumer(IConsumer<Ignore, string> consumer, ILogger<KafkaConsumer> logger)
{
    public void ConsumeMessage(string topic, CancellationToken token, short parallelism = 2)
    {
        consumer.Subscribe(topic);

        var tasks = Enumerable.Range(0, parallelism)
            .Select(_ => Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(token);
                        if (consumeResult.IsPartitionEOF)
                        {
                            Console.WriteLine($"Reached end of partition for topic {topic}");
                            continue;
                        }

                        var message = consumeResult.Message.Value;
                        Console.WriteLine($"Received message: {message}");
                        ProcessMessage(message);
                        consumer.Commit(consumeResult);

                        logger.LogInformation($"Consume message from {topic}: {consumeResult.Message.Value}");
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, e.Message);
                        return;
                    }
                }
            }, token))
            .ToArray();

        Task.WaitAll(tasks, token);
    }

    private static void ProcessMessage(string message)
    {
        Console.WriteLine($"Processing message: {message}");
    }
}