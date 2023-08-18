namespace Basket.API.Extensions;
public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddControllers();

        services.AddStackExchangeRedisCache(options =>
            options.Configuration = config.GetValue<string>("CacheSettings:ConnectionString"));

        services.AddScoped<IBasketRepository, BasketRepository>();

        return services;
    }
}
