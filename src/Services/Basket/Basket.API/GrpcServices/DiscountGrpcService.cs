namespace Basket.API.GrpcServices;
public sealed class DiscountGrpcService
{
    private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

    public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
    {
        _discountProtoService = discountProtoService ??
            throw new ArgumentNullException(nameof(discountProtoService));
    }

    public async Task<CouponResponse> GetDiscountAsync(string productName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(productName));

        var discountRequest = new GetDiscountRequest
        {
            ProductName = productName
        };

        return await _discountProtoService.GetDiscountAsync(discountRequest);
    }

}
