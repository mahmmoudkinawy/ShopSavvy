namespace Basket.API.Extensions;
public static class MessagesServiceExtensions
{
    public static IServiceCollection AddMessageServices(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddMassTransit(options =>
        {
            options.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(config.GetValue<string>("EventBusSettings:HostAddress"));
            });
        });

        return services;
    }
}
