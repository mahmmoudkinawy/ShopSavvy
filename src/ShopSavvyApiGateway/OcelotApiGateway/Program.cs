var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(
    $"ocelot.{builder.Environment.EnvironmentName}.json", true, true);

builder.Services.AddOcelot();

var app = builder.Build();

await app.UseOcelot();

await app.RunAsync();
