namespace Discount.API.Controllers;

[Route("api/v{version:apiVersion}/discount")]
[ApiVersion("1.0")]
[ApiController]
public sealed class DiscountController : ControllerBase
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IMapper _mapper;

    public DiscountController(IDiscountRepository discountRepository, IMapper mapper)
    {
        _discountRepository = discountRepository ??
            throw new ArgumentNullException(nameof(discountRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(discountRepository));
    }

    [HttpGet("{productName}", Name = "GetDiscountByProductName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDiscountByProductName(
        [FromRoute] string productName)
    {
        var discount = await _discountRepository.GetDiscountByProductNameAsync(productName);

        return Ok(_mapper.Map<CouponResponse>(discount) ?? new CouponResponse
        {
            Id = 0,
            Amount = 0,
            Description = "No Discount",
            ProductName = "No Discount"
        });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDiscount(
        [FromBody] CreateCouponRequest request)
    {
        var coupon = _mapper.Map<CouponEntity>(request);

        var result = await _discountRepository.CreateDiscountAsync(coupon);

        if (!result)
        {
            return BadRequest("Problem adding this coupon.");
        }

        var couponToReturn = _mapper.Map<CouponResponse>(coupon);

        return CreatedAtRoute(nameof(GetDiscountByProductName), new { productName = coupon.ProductName }, couponToReturn);
    }

    [HttpPut("{couponId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateDiscount(
        [FromRoute] int couponId,
        [FromBody] UpdateCouponRequest request)
    {
        if (!await _discountRepository.IsDiscountExistByCouponIdAsync(couponId))
        {
            return NotFound();
        }

        var discount = await _discountRepository.GetDiscountByCouponIdAsync(couponId);

        _mapper.Map(request, discount);

        await _discountRepository.UpdateDiscountAsync(discount, couponId);

        return NoContent();
    }

    [HttpDelete("{productName}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDiscount(
        [FromRoute] string productName)
    {
        if (!await _discountRepository.IsDiscountExistByProductNameAsync(productName))
        {
            return NotFound();
        }

        var result = await _discountRepository.DeleteDiscountAsync(productName);

        if (!result)
        {
            return BadRequest("Problem removing this coupon.");
        }

        return NoContent();
    }

}
