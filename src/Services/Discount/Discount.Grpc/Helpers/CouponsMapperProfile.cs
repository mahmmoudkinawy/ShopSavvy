namespace Discount.Grpc.Helpers;
public sealed class CouponsMapperProfile : Profile
{
    public CouponsMapperProfile()
    {
        CreateMap<CouponEntity, CouponResponse>();
        CreateMap<CreateDiscountRequest, CouponEntity>();
        CreateMap<UpdateDiscountRequest, CouponEntity>();
    }
}
