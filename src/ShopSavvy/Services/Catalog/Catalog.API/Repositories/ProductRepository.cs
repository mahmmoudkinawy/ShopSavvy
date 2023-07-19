namespace Catalog.API.Repositories;
public sealed class ProductRepository : IProductRepository
{
    private readonly ICatalogDbContext _context;

    public ProductRepository(ICatalogDbContext context)
    {
        _context = context ??
            throw new ArgumentNullException(nameof(context));
    }

    public async Task CreateProductAsync(ProductEntity product)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(product));

        await _context.Products.InsertOneAsync(product);
    }

    public async Task<ProductEntity> GetProductByIdAsync(string productId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(productId));

        return await _context.Products.Find(p => p.Id == productId).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<ProductEntity>> GetProductsAsync()
    {
        return await _context.Products.Find(_ => true).ToListAsync();
    }

    public async Task<IReadOnlyList<ProductEntity>> GetProductsByCategoryNameAsync(string categoryName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(categoryName));

        var filter = Builders<ProductEntity>.Filter.Eq(p => p.Category, categoryName);

        return await _context.Products.Find(filter).ToListAsync();
    }

    public async Task<IReadOnlyList<ProductEntity>> GetProductsByNameAsync(string name)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(name));

        var filter = Builders<ProductEntity>.Filter.Eq(p => p.Name, name);

        return await _context.Products.Find(filter).ToListAsync();
    }

    public async Task<bool> IsProductExistAsync(string productId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(productId));

        return await _context.Products.Find(p => p.Id == productId).AnyAsync();
    }

    public async Task<bool> RemoveProductAsync(string productId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(productId));

        var filter = Builders<ProductEntity>.Filter.Eq(p => p.Id, productId);

        var deleteResult = await _context.Products.DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<bool> UpdateProductAsync(ProductEntity product)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(product));

        var updateResult = await _context.Products
            .ReplaceOneAsync(p => p.Id == product.Id, product);

        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

}
