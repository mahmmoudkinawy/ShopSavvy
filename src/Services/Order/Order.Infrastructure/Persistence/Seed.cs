namespace Order.Infrastructure.Persistence;
public class Seed
{
    public static async Task SeedOrdersAsync(
        OrdersDbContext context)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(context));

        if (await context.Orders.AnyAsync())
        {
            return;
        }

        var orders = new List<OrderEntity>()
        {
            new OrderEntity
            {
                UserName = "kinawy",
                Country = "Egypt",
                AddressLine = "Menofia-Shohdaa",
                EmailAddress = "kinawy@test.com",
                FirstName = "Md",
                LastName = "Kinawy",
                TotalPrice = 12.35M
            },
            new OrderEntity
            {
                UserName = "aya",
                Country = "Egypt",
                AddressLine = "Menofia-Sadat",
                EmailAddress = "aya@test.com",
                FirstName = "Aya",
                LastName = "Mahmoud",
                TotalPrice = 1526M
            }
        };

        context.Orders.AddRange(orders);
        await context.SaveChangesAsync();
    }
}
