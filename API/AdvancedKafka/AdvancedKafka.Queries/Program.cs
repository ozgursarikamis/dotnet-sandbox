using AdvancedKafka.Entities;
using AdvancedKafka.Shared.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load Configurations
var kafkaSettings = builder.Configuration.GetSection("KafkaSettings").Get<KafkaSettings>();
var dbSettings = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();

// Register Configurations
builder.Services.AddSingleton(kafkaSettings);
builder.Services.AddSingleton(dbSettings);

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(dbSettings.ConnectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
DbInitializer.EnsureDatabaseCreated(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();