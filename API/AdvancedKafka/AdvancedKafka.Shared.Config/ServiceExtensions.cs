using AdvancedKafka.Entities;
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
}