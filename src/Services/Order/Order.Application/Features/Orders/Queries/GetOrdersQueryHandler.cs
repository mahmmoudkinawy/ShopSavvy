namespace Order.Application.Features.Orders.Queries;
public sealed class GetOrdersQueryHandler
    : IRequestHandler<GetOrdersQuery, IReadOnlyList<OrderResponse>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersQueryHandler(
        IOrderRepository orderRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository ??
            throw new ArgumentNullException(nameof(orderRepository));
        _mapper = mapper??
            throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IReadOnlyList<OrderResponse>> Handle(
        GetOrdersQuery request, 
        CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersByUserNameAsync(request.UserName);

        return _mapper.Map<IReadOnlyList<OrderResponse>>(orders);
    }

}
