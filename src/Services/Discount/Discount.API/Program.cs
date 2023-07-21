var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(_ => _.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(opts =>
{
    opts.AssumeDefaultVersionWhenUnspecified = true;
    opts.ReportApiVersions = true;
    opts.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddVersionedApiExplorer(opts => opts.GroupNameFormat = "'v'VVV");

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new DbConnectionFactory(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString")!));

builder.Services.AddSingleton<DatabaseInitializer>();

builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

await app.RunAsync();
