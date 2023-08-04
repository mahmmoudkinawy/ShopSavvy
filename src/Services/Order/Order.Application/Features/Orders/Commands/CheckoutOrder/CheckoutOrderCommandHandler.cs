namespace Order.Application.Features.Orders.Commands.CheckoutOrder;
public sealed class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly ILogger<CheckoutOrderCommandHandler> _logger;

    public CheckoutOrderCommandHandler(
        IOrderRepository orderRepository,
        IMapper mapper,
        IEmailService emailService,
        ILogger<CheckoutOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository ??
            throw new ArgumentNullException(nameof(orderRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
        _emailService = emailService ??
            throw new ArgumentNullException(nameof(emailService));
        _logger = logger ??
            throw new ArgumentNullException(nameof(logger));
    }

    public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToCreate = _mapper.Map<OrderEntity>(request);

        var orderCreationResult = await _orderRepository.AddAsync(orderToCreate);

        try
        {
            await _emailService.SendEmailAsync(
                request.EmailAddress,
                "Order was created.",
                "Order was created.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Order {orderCreationResult.Id} failed due to an error with the email service: {ex.Message}");
        }

        return orderCreationResult.Id;
    }

}
