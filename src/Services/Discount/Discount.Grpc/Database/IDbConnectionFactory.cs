namespace Discount.Grpc.Database;
public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
}
