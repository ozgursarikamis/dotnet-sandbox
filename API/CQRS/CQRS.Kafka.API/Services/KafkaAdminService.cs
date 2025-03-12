using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace CQRS.Kafka.API.Services;

public class KafkaAdminService
{
    private readonly AdminClientConfig adminClientConfig = new()
    {
        BootstrapServers = "localhost:9092",
    };

    public async Task CreateTopicIfNotExists(
        string topicName,
        short partitionCount = 3,
        short replicationFactor = 1
        )
    {
        using var adminClient = new AdminClientBuilder(adminClientConfig).Build();
        var metaData = adminClient.GetMetadata(TimeSpan.FromSeconds(5));

        if (!metaData.Topics.Exists(t => t.Topic == topicName))
        {
            await adminClient.CreateTopicsAsync([
                new TopicSpecification{ Name = topicName, NumPartitions = partitionCount, ReplicationFactor = replicationFactor }
            ]);

            Console.WriteLine($"✅ Kafka topic '{topicName}' created.");
        }
        else
        {
            Console.WriteLine($"⚠️ Kafka topic '{topicName}' already exists.");
        }
    }
}