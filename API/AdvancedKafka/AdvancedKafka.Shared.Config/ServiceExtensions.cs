using AdvancedKafka.Entities;
using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedKafka.Shared.Config;

public static class ServiceExtensions
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("DatabaseSettings:ConnectionString")
            .Value;

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }

    public static IServiceCollection AddKafkaSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<KafkaSettings>(configuration.GetSection("KafkaSettings"));
        return services;
    }
    
    // Kafka Consumer & Producer
    public static IServiceCollection AddKafkaProducer(this IServiceCollection services, IConfiguration configuration)
    {
        var kafkaSettings = configuration.GetSection("KafkaSettings").Get<KafkaSettings>();
        services.AddSingleton<IProducer<Null, string>>(_ =>
        {
            var config = new ProducerConfig
            {
                BootstrapServers = kafkaSettings?.BootstrapServers,
            };
            return new ProducerBuilder<Null, string>(config).Build();
        });
        
        // Register the KafkaProducer as a service
        services.AddSingleton<KafkaProducer>();
        
        return services;
    }

    public static IServiceCollection AddKafkaConsumer(
        this IServiceCollection services, 
        IConfiguration configuration,
        string groupId = "advanced-kafka-group"
        )
    {
        var kafkaSettings = configuration.GetSection("KafkaSettings").Get<KafkaSettings>();
        services.AddSingleton<IConsumer<Ignore, string>>(_ =>
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = kafkaSettings?.BootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false,
                EnablePartitionEof = true
            };

            return new ConsumerBuilder<Ignore, string>(config).Build();
        });
        
        // Register the KafkaProducer as a service
        services.AddSingleton<KafkaConsumer>();
        return services;
    }
}