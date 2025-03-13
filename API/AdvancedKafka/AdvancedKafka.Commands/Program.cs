using AdvancedKafka.Shared.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services
var builderConfiguration = builder.Configuration;
builder.Services.AddDatabaseContext(builderConfiguration);
builder.Services.AddKafkaSettings(builderConfiguration);
builder.Services.AddKafkaProducer(builderConfiguration);
builder.Services.AddKafkaConsumer(builderConfiguration);

// Add MVC services for controllers
builder.Services.AddControllers();

// Build app
var app = builder.Build();

// Initialize app (Ensures DB creation and applies migrations)
AppInitializer.InitializeApp(app);

app.MapControllers();

// Run the app
app.Run();