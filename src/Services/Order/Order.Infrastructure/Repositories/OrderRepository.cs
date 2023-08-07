namespace Order.Infrastructure.Repositories;
public sealed class OrderRepository : RepositoryBase<OrderEntity>, IOrderRepository
{
    private readonly OrdersDbContext _context;

    public OrderRepository(OrdersDbContext context) : base(context)
    {
        _context = context ??
            throw new ArgumentNullException(nameof(context));
    }

    public async Task<IReadOnlyList<OrderEntity>> GetOrdersByUserNameAsync(string userName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(userName));

        return await _context.Orders
            .Where(o => o.UserName == userName)
            .AsNoTracking()
            .ToListAsync();
    }
}
