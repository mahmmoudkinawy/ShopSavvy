namespace Basket.API.Repositories;
public interface IBasketRepository
{
    Task<CartModel> GetBasketByUserNameAsync(string userName);
    Task<CartModel> UpdateBasketAsync(CartModel cart);
    Task DeleteBasketAsync(string userName);
}
