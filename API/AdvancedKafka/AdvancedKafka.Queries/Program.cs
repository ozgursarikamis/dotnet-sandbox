using AdvancedKafka.Shared.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDatabaseContext(builder.Configuration);
builder.Services.AddKafkaSettings(builder.Configuration);

// Build app
var app = builder.Build();

// Initialize app (Ensures DB creation and applies migrations)
AppInitializer.InitializeApp(app);

// Map endpoints or controllers
app.MapControllers();

// Run the app
app.Run();