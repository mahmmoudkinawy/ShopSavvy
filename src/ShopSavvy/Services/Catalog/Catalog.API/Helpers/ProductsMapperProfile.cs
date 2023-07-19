namespace Catalog.API.Helpers;
public sealed class ProductsMapperProfile : Profile
{
    public ProductsMapperProfile()
    {
        CreateMap<ProductEntity, ProductResponse>();
        CreateMap<ProductCreateRequest, ProductEntity>();
    }
}
