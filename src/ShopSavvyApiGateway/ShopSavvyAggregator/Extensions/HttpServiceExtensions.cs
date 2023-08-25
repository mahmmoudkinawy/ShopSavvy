namespace ShopSavvyAggregator.Extensions;
public static class HttpServiceExtensions
{
    public static IServiceCollection AddHttpServices(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddHttpClient<ICatalogService, CatalogService>(options =>
        {
            options.BaseAddress = new Uri(config["ServiceUrls:CatalogUrl"]);
            options.DefaultRequestHeaders.Clear();
            options.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        })
            .AddPolicyHandler(GetRetryPolicy());

        services.AddHttpClient<IBasketService, BasketService>(options =>
        {
            options.BaseAddress = new Uri(config["ServiceUrls:BasketUrl"]);
            options.DefaultRequestHeaders.Clear();
            options.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        })
            .AddPolicyHandler(GetRetryPolicy());

        services.AddHttpClient<IOrderService, OrderService>(options =>
        {
            options.BaseAddress = new Uri(config["ServiceUrls:OrderUrl"]);
            options.DefaultRequestHeaders.Clear();
            options.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        })
            .AddPolicyHandler(GetRetryPolicy());

        return services;
    }

    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

}
