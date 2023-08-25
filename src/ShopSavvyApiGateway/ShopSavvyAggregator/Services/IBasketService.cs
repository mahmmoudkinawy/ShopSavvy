namespace ShopSavvyAggregator.Services;
public interface IBasketService
{
    Task<BasketResponse> GetBasketByUserNameAsync(string userName);
}
