namespace Order.Application.Contracts.Persistence;
public interface IOrderRepository : IAsyncRepository<OrderEntity>
{
    Task<IReadOnlyList<OrderEntity>> GetOrdersByUserNameAsync(string userName);
}
