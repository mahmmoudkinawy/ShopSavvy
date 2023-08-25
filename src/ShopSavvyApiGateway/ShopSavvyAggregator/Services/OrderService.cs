namespace ShopSavvyAggregator.Services;
public sealed class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient ??
            throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<IReadOnlyList<OrderResponse>> GetOrdersByUserNameAsync(string userName)
    {
        var orders = await _httpClient.GetAsync($"/api/v1/orders/{userName}");

        return await orders.ReadContentAsAsync<IReadOnlyList<OrderResponse>>();
    }
}
