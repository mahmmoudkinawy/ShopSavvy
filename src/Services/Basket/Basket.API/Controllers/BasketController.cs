namespace Basket.API.Controllers;

[Route("api/v{version:apiVersion}/basket")]
[ApiVersion("1.0")]
[ApiController]
public sealed class BasketController : ControllerBase
{
    private readonly IBasketRepository _basketRepository;
    private readonly DiscountGrpcService _discountGrpcService;

    public BasketController(
        IBasketRepository basketRepository,
        DiscountGrpcService discountGrpcService)
    {
        _basketRepository = basketRepository ??
            throw new ArgumentNullException(nameof(basketRepository));
        _discountGrpcService = discountGrpcService ??
            throw new ArgumentNullException(nameof(discountGrpcService));
    }

    [HttpGet("{userName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBasketByUserName(
        [FromRoute] string userName)
    {
        var basket = await _basketRepository.GetBasketByUserNameAsync(userName);

        return Ok(basket ?? new CartModel { UserName = userName });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateBasket(
        [FromBody] CartModel cart)
    {
        foreach (var item in cart.Items)
        {
            var coupon = await _discountGrpcService.GetDiscountAsync(item.ProductName);

            if (coupon is not null)
            {
                item.Price -= coupon.Amount;
            }
        }

        var basketToCreate = await _basketRepository.UpdateBasketAsync(cart);

        return Ok(basketToCreate);
    }

    [HttpDelete("{userName}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteBasket(
        [FromRoute] string userName)
    {
        await _basketRepository.DeleteBasketAsync(userName);

        return NoContent();
    }

}
