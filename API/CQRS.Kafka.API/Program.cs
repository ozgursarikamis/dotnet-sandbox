using CQRS.Kafka.API.Database;
using CQRS.Kafka.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<BankDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString);
});

// Existing Kafka services
builder.Services.AddSingleton<KafkaAdminService>();
builder.Services.AddSingleton<KafkaProducerService>();
builder.Services.AddScoped<BankCommandService>();

var app = builder.Build();
// Create Kafka topics BEFORE starting the web server
using (var scope = app.Services.CreateScope())
{
    var kafkaAdmin = scope.ServiceProvider.GetRequiredService<KafkaAdminService>();
    var task = Task.Run(async () => await kafkaAdmin.CreateTopicIfNotExists("bank-events"));
    task.Wait(); // Ensure it completes before proceeding

    var dbContext = scope.ServiceProvider.GetRequiredService<BankDbContext>();
    var pendingMigrationsAsyncTask = dbContext.Database.GetPendingMigrationsAsync();
    var pendingMigrationsExist = (await pendingMigrationsAsyncTask).Any();
    
    pendingMigrationsAsyncTask.Wait();
    await dbContext.Database.EnsureCreatedAsync();
    if (pendingMigrationsExist)
        await dbContext.Database.MigrateAsync();
}

app.UseRouting();
app.MapControllers();

app.Run();