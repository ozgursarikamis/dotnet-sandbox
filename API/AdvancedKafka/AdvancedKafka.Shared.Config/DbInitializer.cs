using AdvancedKafka.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdvancedKafka.Shared.Config;

public static class AppInitializer
{
    public static void InitializeApp(IHost app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        // Ensure the database is created before applying migrations
        var databaseCreated = dbContext.Database.EnsureCreated();

        Console.WriteLine(databaseCreated ? "Database created!" : "Database already exists.");

        dbContext.Database.Migrate();
    }
}