namespace Catalog.API.DbContexts;
public sealed class CatalogDbContext : ICatalogDbContext
{
    public CatalogDbContext(IConfiguration config)
    {
        var client = new MongoClient(config.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(config.GetValue<string>("DatabaseSettings:DatabaseName"));

        Products = database.GetCollection<ProductEntity>(config.GetValue<string>("DatabaseSettings:CollectionName"));
    }

    public IMongoCollection<ProductEntity> Products { get; }
}