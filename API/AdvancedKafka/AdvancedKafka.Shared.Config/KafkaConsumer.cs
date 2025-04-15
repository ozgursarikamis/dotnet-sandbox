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

    public void ConsumeFromPartition(string topic, int partitionId, CancellationToken token, int parallelism = 2)
    {
        var topicPartition = new TopicPartition(topic, new Partition(partitionId));
        // Assign consumer to a specific partition:
        consumer.Assign(topicPartition);

        Console.WriteLine($"Consuming from partition {partitionId} from topic {topic}, Parallelism {parallelism}");

        var tasks = Enumerable.Range(0, parallelism)
            .Select(_ => Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(token);
                        var message = consumeResult.Message.Value;

                        Console.WriteLine($"Received message: {message}");
                        ProcessMessage(message);

                        // Manually commit after processing:
                        consumer.Commit(consumeResult);
                    }
                    catch (ConsumeException consumeException)
                    {
                        Console.WriteLine($"Kafka consume exception: {consumeException.Message}");
                    }
                }
            })).ToArray();
        
        Task.WaitAll(tasks, token);
    }

    private static void ProcessMessage(string message)
    {
        Console.WriteLine($"Processing message: {message}");
    }
}