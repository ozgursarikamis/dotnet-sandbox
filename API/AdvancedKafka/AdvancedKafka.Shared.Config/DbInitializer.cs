using AdvancedKafka.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedKafka.Shared.Config;

public static class DbInitializer
{
    public static void EnsureDatabaseCreated(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        var databaseCreated = dbContext.Database.EnsureCreated();
        Console.WriteLine(databaseCreated ? "Database created" : "Database already exists");
        dbContext.Database.Migrate();
    }
}