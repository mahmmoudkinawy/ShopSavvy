namespace Discount.API.Database;
public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
}
