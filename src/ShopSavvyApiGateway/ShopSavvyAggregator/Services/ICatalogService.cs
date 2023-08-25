namespace ShopSavvyAggregator.Services;
public interface ICatalogService
{
    Task<IReadOnlyList<CatalogResponse>> GetCatalogsAsync();
    Task<IReadOnlyList<CatalogResponse>> GetCatalogsByCategoryNameAsync(string categoryName);
    Task<CatalogResponse> GetCatalogByIdAsync(string catalogId);
}
