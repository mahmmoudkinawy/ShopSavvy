namespace Order.API.Controllers;

[Route("api/v{version:apiVersion}/orders")]
[ApiVersion("1.0")]
[ApiController]
public sealed class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator ??
            throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("{userName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrdersByUserName(
        [FromRoute] string userName)
    {
        var response = await _mediator.Send(new GetOrdersQuery
        {
            UserName = userName
        });

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CheckoutOrder(
        [FromBody] CheckoutOrderCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateOrder(
        [FromBody] UpdateOrderCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{orderId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteOrder(
        [FromRoute] int orderId)
    {
        await _mediator.Send(new DeleteOrderCommand
        {
            Id = orderId
        });

        return NoContent();
    }

}
