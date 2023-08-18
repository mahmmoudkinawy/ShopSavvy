namespace Basket.API.Extensions;
public static class GrpcServiceExtensions
{
    public static IServiceCollection AddGrpcServices(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(
            options => options.Address = new Uri(config.GetValue<string>("GrpcSettings:DiscountUri")));

        services.AddScoped<DiscountGrpcService>();

        return services;
    }
}
