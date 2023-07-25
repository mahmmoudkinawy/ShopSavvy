namespace Discount.Grpc.Database;
public sealed class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory ??
            throw new ArgumentNullException(nameof(connectionFactory));
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        await connection.ExecuteAsync(
            "DROP TABLE IF EXISTS Coupons;"
        );

        await connection.ExecuteAsync(
            @"CREATE TABLE IF NOT EXISTS Coupons(
                    Id SERIAL PRIMARY KEY,
                    ProductName VARCHAR(1000),
                    Description TEXT,
                    Amount DECIMAL(10, 2)
                );"
        );

        await connection.ExecuteAsync(
        @"CREATE INDEX IF NOT EXISTS idx_Coupons_ProductName ON Coupons (ProductName);");

        var rowCount = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Coupons;");

        if (rowCount == 0)
        {
            await connection.ExecuteAsync(
                @"INSERT INTO Coupons(ProductName, Description, Amount) VALUES
                ('IPhone X', 'I Phone Discount', 12.34),
                ('Samsung 10', 'Samsung Discount', 56.78)");
        }
    }

}
