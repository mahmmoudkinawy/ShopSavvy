namespace Basket.API.Repositories;
public sealed class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _cache;

    public BasketRepository(IDistributedCache cache)
    {
        _cache = cache ??
            throw new ArgumentNullException(nameof(cache));
    }

    public async Task DeleteBasketAsync(string userName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(userName));

        await _cache.RemoveAsync(userName);
    }

    public async Task<CartModel> GetBasketByUserNameAsync(string userName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(userName));

        var basket = await _cache.GetStringAsync(userName);

        if (string.IsNullOrEmpty(basket))
        {
            return null;
        }

        return JsonConvert.DeserializeObject<CartModel>(basket)!;
    }

    public async Task<CartModel> UpdateBasketAsync(CartModel cart)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(cart));

        await _cache.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));

        return await GetBasketByUserNameAsync(cart.UserName);
    }
}
