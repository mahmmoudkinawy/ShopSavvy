var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(opts =>
{
    opts.AssumeDefaultVersionWhenUnspecified = true;
    opts.ReportApiVersions = true;
    opts.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddVersionedApiExplorer(opts => opts.GroupNameFormat = "'v'VVV");

builder.Services.AddStackExchangeRedisCache(options => 
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString"));

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(_ => _.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
}

app.MapControllers();

await app.RunAsync();
