var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerServices();

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddMessageServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

using var scope = app.Services.CreateScope();
var ordersDbContext = scope.ServiceProvider.GetRequiredService<OrdersDbContext>();
try
{
    await ordersDbContext.Database.MigrateAsync();
    await Seed.SeedOrdersAsync(ordersDbContext);
}
catch (Exception ex)
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError("Order.API - An error occurred while applying pending migrations.", ex.Message);
    throw;
}

app.Run();
