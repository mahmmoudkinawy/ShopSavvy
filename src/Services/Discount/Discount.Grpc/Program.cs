var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new DbConnectionFactory(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString")!));

builder.Services.AddSingleton<DatabaseInitializer>();

builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<DiscountService>();

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

await app.RunAsync();
