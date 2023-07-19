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

builder.Services.AddScoped<ICatalogDbContext, CatalogDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(_ => _.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
}

app.MapControllers();

using var scope = app.Services.CreateScope();
var catalogDbContext = scope.ServiceProvider.GetRequiredService<ICatalogDbContext>();
try
{
    await Seed.SeedProductsAsync(catalogDbContext.Products);
}
catch (Exception ex)
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError("Catalog.API - An error occurred while seeding.", ex);
}

await app.RunAsync();
