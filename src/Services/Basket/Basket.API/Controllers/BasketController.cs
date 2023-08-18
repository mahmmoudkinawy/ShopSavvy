namespace Basket.API.Controllers;

[Route("api/v{version:apiVersion}/basket")]
[ApiVersion("1.0")]
[ApiController]
public sealed class BasketController : ControllerBase
{
    private readonly IBasketRepository _basketRepository;
    private readonly DiscountGrpcService _discountGrpcService;
    private readonly IPublishEndpoint _publishEndpoint;

    public BasketController(
        IBasketRepository basketRepository,
        IPublishEndpoint publishEndpoint,
        DiscountGrpcService discountGrpcService)
    {
        _basketRepository = basketRepository ??
            throw new ArgumentNullException(nameof(basketRepository));
        _publishEndpoint = publishEndpoint ??
            throw new ArgumentNullException(nameof(publishEndpoint));
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

    [HttpPost("checkout")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Checkout(
        [FromBody] BasketCheckoutModel basketCheckout)
    {
        var basket = await _basketRepository
            .GetBasketByUserNameAsync(basketCheckout.UserName);

        if (basket is null)
        {
            return NotFound();
        }

        var basketCheckoutEvent = basketCheckout.MapToBasketCheckoutEvent();

        basketCheckoutEvent.TotalPrice = basket.TotalPrice;

        await _publishEndpoint.Publish(basketCheckoutEvent);

        await _basketRepository.DeleteBasketAsync(basketCheckout.UserName);

        return Accepted();
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
