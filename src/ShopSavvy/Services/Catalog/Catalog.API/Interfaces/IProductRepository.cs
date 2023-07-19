namespace Catalog.API.Interfaces;
public interface IProductRepository
{
    Task<IReadOnlyList<ProductEntity>> GetProductsAsync();
    Task<IReadOnlyList<ProductEntity>> GetProductsByNameAsync(string name);
    Task<IReadOnlyList<ProductEntity>> GetProductsByCategoryNameAsync(string categoryName);
    Task<ProductEntity> GetProductByIdAsync(string productId);
    Task CreateProductAsync(ProductEntity product);
    Task<bool> UpdateProductAsync(ProductEntity product);
    Task<bool> RemoveProductAsync(string productId);
    Task<bool> IsProductExistAsync(string productId);
}
