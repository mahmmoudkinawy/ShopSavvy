namespace Catalog.API.DbContexts;
public interface ICatalogDbContext
{
    IMongoCollection<ProductEntity> Products { get; }
}
