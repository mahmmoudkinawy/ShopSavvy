namespace ShopSavvyAggregator.Services;
public sealed class CatalogService : ICatalogService
{
    private readonly HttpClient _httpClient;

    public CatalogService(HttpClient httpClient)
    {
        _httpClient = httpClient ??
            throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<CatalogResponse> GetCatalogByIdAsync(string catalogId)
    {
        var catalog = await _httpClient.GetAsync($"/api/v1/catalogs/{catalogId}");

        return await catalog.ReadContentAsAsync<CatalogResponse>();
    }

    public async Task<IReadOnlyList<CatalogResponse>> GetCatalogsAsync()
    {
        var catalogs = await _httpClient.GetAsync("/api/v1/catalogs");

        return await catalogs.ReadContentAsAsync<IReadOnlyList<CatalogResponse>>();
    }

    public async Task<IReadOnlyList<CatalogResponse>> GetCatalogsByCategoryNameAsync(
        string categoryName)
    {
        var catalogs = await _httpClient.GetAsync(
            $"/api/v1/catalogs/filter-by-category-name/{categoryName}");

        return await catalogs.ReadContentAsAsync<IReadOnlyList<CatalogResponse>>();
    }
}
