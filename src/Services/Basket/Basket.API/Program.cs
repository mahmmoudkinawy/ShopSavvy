var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerServices();

builder.Services.AddGrpcServices(builder.Configuration);

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddMessageServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(_ => _.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
}

app.MapControllers();

await app.RunAsync();
