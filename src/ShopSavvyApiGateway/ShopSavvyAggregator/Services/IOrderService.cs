namespace ShopSavvyAggregator.Services;
public interface IOrderService
{
    Task<IReadOnlyList<OrderResponse>> GetOrdersByUserNameAsync(string userName);
}
