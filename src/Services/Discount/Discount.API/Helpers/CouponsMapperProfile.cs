namespace Discount.API.Helpers;
public sealed class CouponsMapperProfile : Profile
{
    public CouponsMapperProfile()
    {
        CreateMap<CouponEntity, CouponResponse>();
        CreateMap<CreateCouponRequest, CouponEntity>();
        CreateMap<UpdateCouponRequest, CouponEntity>();
    }
}
