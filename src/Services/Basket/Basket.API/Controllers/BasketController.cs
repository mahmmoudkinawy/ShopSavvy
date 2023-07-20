namespace Basket.API.Controllers;

[Route("api/{version:apiVersion}/basket")]
[ApiVersion("1.0")]
[ApiController]
public sealed class BasketController : ControllerBase
{
    private readonly IBasketRepository _basketRepository;

    public BasketController(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository ??
            throw new ArgumentNullException(nameof(basketRepository));
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
