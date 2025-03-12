using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CQRS.Kafka.API.Consumer;

public class KafkaConsumerService(IServiceScopeFactory scopeFactory, ILogger<KafkaConsumerService> logger) : BackgroundService
{
    private const string BANK_EVENTS = "bank-events";
    private const string BANK_CONSUMER_GROUP = "bank-group";
    private ILogger<KafkaConsumerService> Logger { get; } = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Logger.LogInformation("KafkaConsumerService running at: {time}", DateTimeOffset.Now);

        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = BANK_CONSUMER_GROUP,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        
        using var consumer = new ConsumerBuilder<string, string>(config).Build();
        consumer.Subscribe(BANK_EVENTS);

        while (!stoppingToken.IsCancellationRequested)
        {
            var consumeResult = consumer.Consume(stoppingToken);
            var message = consumeResult.Message.Value;
            
            Logger.LogInformation("KafkaConsumerService consumes: {message}", message);
        }

        // while (!stoppingToken.IsCancellationRequested)
        // {
        //     var consumeResult = consumer.Consume(stoppingToken);
        //     var message = consumeResult.Message.Value;
        //
        //     using var scope = scopeFactory.CreateScope();
        //     var dbContext = scope.ServiceProvider.GetRequiredService<BankDbContext>();
        //
        //     var @event = JsonSerializer.Deserialize<MoneyDeposited>(message);
        //     if (@event == null) continue;
        //     
        //     dbContext.Transactions.Add(new Transaction
        //     {
        //         AccountId = @event.AccountId,
        //         Amount = @event.Amount,
        //         Timestamp = @event.Timestamp
        //     });
        //
        //     await dbContext.SaveChangesAsync(stoppingToken);
        // }
    }
}