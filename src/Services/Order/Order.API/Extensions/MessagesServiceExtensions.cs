namespace Order.API.Extensions;
public static class MessagesServiceExtensions
{
    public static IServiceCollection AddMessageServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMassTransit(config =>
        {
             config.AddConsumer<BasketCheckoutConsumer>();

             config.UsingRabbitMq((ctx, cfg) =>
             {
                 cfg.Host(configuration.GetValue<string>("EventBusSettings:HostAddress"));

                 cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c =>
                 {
                     c.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
                 });
             });
        });

        services.AddScoped<BasketCheckoutConsumer>();

        return services;
    }
}
