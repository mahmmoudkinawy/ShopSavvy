namespace ShopSavvyAggregator.Services;
public sealed class BasketService : IBasketService
{
    private readonly HttpClient _httpClient;

    public BasketService(HttpClient httpClient)
    {
        _httpClient = httpClient ??
            throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<BasketResponse> GetBasketByUserNameAsync(string userName)
    {
        var basket = await _httpClient.GetAsync($"api/v1/basket/{userName}");

        return await basket.ReadContentAsAsync<BasketResponse>();
    }
}
