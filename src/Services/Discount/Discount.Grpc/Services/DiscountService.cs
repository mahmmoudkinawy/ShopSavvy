namespace Discount.Grpc.Services;
public sealed class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DiscountService> _logger;

    public DiscountService(
        IDiscountRepository discountRepository,
        IMapper mapper,
        ILogger<DiscountService> logger)
    {
        _discountRepository = discountRepository ??
            throw new ArgumentNullException(nameof(discountRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
        _logger = logger ??
            throw new ArgumentNullException(nameof(logger));
    }

    public override async Task<CouponResponse> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await _discountRepository.GetDiscountByProductNameAsync(request.ProductName);

        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound,
                $"Discount with this Product Name={request.ProductName} does not exist."));
        }

        _logger.LogInformation("Discount is retrieved for ProductName: {productName}, Amount: {amount}", coupon.ProductName, coupon.Amount);

        return _mapper.Map<CouponResponse>(coupon);
    }

    public override async Task<CouponResponse> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = _mapper.Map<CouponEntity>(request.Coupon);

        await _discountRepository.CreateDiscountAsync(coupon);

        _logger.LogInformation("Discount is successfully created. ProductName : {productName}", coupon.ProductName);

        return _mapper.Map<CouponResponse>(coupon);
    }

    public override async Task<CouponResponse> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = await _discountRepository.GetDiscountByCouponIdAsync(request.Coupon.Id);

        _mapper.Map(request, coupon);

        await _discountRepository.UpdateDiscountAsync(coupon, request.Coupon.Id);

        return _mapper.Map<CouponResponse>(coupon);
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        return new DeleteDiscountResponse
        {
            Success = await _discountRepository.DeleteDiscountAsync(request.ProductName)
        };
    }

}
