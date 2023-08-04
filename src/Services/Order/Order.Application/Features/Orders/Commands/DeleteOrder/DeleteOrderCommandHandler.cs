namespace Order.Application.Features.Orders.Commands.DeleteOrder;
public sealed class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateOrderCommandHandler> _logger;

    public DeleteOrderCommandHandler(
        IOrderRepository orderRepository,
        IMapper mapper,
        ILogger<UpdateOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository ??
            throw new ArgumentNullException(nameof(orderRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
        _logger = logger ??
            throw new ArgumentNullException(nameof(logger));
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderFromDb = await _orderRepository.GetByIdAsync(request.Id);

        if (orderFromDb is null)
        {
            _logger.LogError("Order not exist on database.");
            throw new NotFoundException(nameof(OrderEntity), request.Id);
        }

        await _orderRepository.DeleteAsync(orderFromDb);

        _logger.LogInformation($"Order {orderFromDb.Id} is successfully deleted.");
    }

}
