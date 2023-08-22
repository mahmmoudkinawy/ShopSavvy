namespace Order.API.Consumers;
public sealed class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
{
    private readonly IMediator _mediator;
    private readonly ILogger<BasketCheckoutConsumer> _logger;

    public BasketCheckoutConsumer(
        IMediator mediator,
        ILogger<BasketCheckoutConsumer> logger)
    {
        _mediator = mediator ??
            throw new ArgumentNullException(nameof(mediator));
        _logger = logger ??
            throw new ArgumentNullException(nameof(logger));
    }

    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        var command = context.Message.MapToCheckoutOrderCommand();

        var result = await _mediator.Send(command);

        _logger.LogInformation("Basket Checkout Event consumed successfully. Order Id is: {orderId}", result);
    }
}
