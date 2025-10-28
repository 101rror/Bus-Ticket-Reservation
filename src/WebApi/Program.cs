using Application.Services;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var defaultConn = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
var selectedProvider = "InMemory";
if (defaultConn.Contains("Host=", StringComparison.OrdinalIgnoreCase) || defaultConn.Contains("User Id=", StringComparison.OrdinalIgnoreCase))
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(defaultConn));
    selectedProvider = "Npgsql(Postgres)";
}
else if (defaultConn.Contains("Data Source=", StringComparison.OrdinalIgnoreCase) || defaultConn.EndsWith(".db", StringComparison.OrdinalIgnoreCase))
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(defaultConn));
    selectedProvider = "Sqlite";
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("BusTicketInMemory"));
}

Console.WriteLine($"Selected DB provider: {selectedProvider}. Connection string present: {(!string.IsNullOrEmpty(defaultConn))}");

builder.Services.AddScoped<SearchService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<IBusService, BusService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularDev");

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<Infrastructure.Persistence.AppDbContext>();
        db.Database.EnsureCreated();
        logger.LogInformation("Database ensured/created successfully.");
    }
    catch (Exception ex)
    {
        logger.LogWarning(ex, "Could not ensure or create the database. Continuing without database initialization.");
    }
}

app.Run();
