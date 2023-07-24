namespace Discount.Grpc.Repositories;
public sealed class DiscountRepository : IDiscountRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DiscountRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory ??
            throw new ArgumentNullException(nameof(connectionFactory));
    }

    public async Task<bool> CreateDiscountAsync(CouponEntity coupon)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(coupon));

        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO Coupons(ProductName, Description, Amount) 
                  VALUES(@ProductName, @Description, @Amount);",
            new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

        return result > 0;
    }

    public async Task<bool> DeleteDiscountAsync(string productName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(productName));

        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            "DELETE FROM Coupons WHERE ProductName = @ProductName;",
            new { ProductName = productName });

        return result > 0;
    }

    public async Task<CouponEntity?> GetDiscountByCouponIdAsync(int couponId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(couponId));

        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryFirstOrDefaultAsync<CouponEntity>(
            "SELECT * FROM Coupons WHERE Id = @CouponId;",
            new { CouponId = couponId });
    }

    public async Task<CouponEntity?> GetDiscountByProductNameAsync(string productName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(productName));

        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryFirstOrDefaultAsync<CouponEntity>(
            "SELECT * FROM Coupons WHERE ProductName = @ProductName LIMIT 1;",
            new { ProductName = productName });
    }

    public async Task<bool> IsDiscountExistByCouponIdAsync(int discountId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(discountId));

        using var connection = await _connectionFactory.CreateConnectionAsync();
        var rowCount = await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM Coupons WHERE Id = @DiscountId;",
            new { DiscountId = discountId });

        return rowCount > 0;
    }

    public async Task<bool> IsDiscountExistByProductNameAsync(string productName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(productName));

        using var connection = await _connectionFactory.CreateConnectionAsync();
        var rowCount = await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM Coupons WHERE ProductName = @ProductName;",
            new { ProductName = productName });

        return rowCount > 0;
    }

    public async Task<bool> UpdateDiscountAsync(CouponEntity coupon, int couponId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(coupon));

        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE Coupons SET ProductName = @ProductName, Description = @Description, Amount = @Amount 
                  WHERE Id = @CouponId;",
            new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, CouponId = couponId });

        return result > 0;
    }
}
