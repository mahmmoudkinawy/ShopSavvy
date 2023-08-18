namespace Basket.API.Extensions;
public static class SwaggerServiceExtensions
{
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        services.AddApiVersioning(opts =>
         {
            opts.AssumeDefaultVersionWhenUnspecified = true;
            opts.ReportApiVersions = true;
            opts.DefaultApiVersion = new ApiVersion(1, 0);
         });

        services.AddVersionedApiExplorer(opts => opts.GroupNameFormat = "'v'VVV");

        return services;
    }
}
