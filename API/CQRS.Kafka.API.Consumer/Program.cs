using CQRS.Kafka.API.Consumer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<KafkaConsumerService>();
    })
    .ConfigureLogging(logging =>
    {
        Console.WriteLine("Logging configured");
    })
    .Build();

await host.RunAsync();