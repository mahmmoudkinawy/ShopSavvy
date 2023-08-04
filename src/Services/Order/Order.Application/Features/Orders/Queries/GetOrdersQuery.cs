namespace Order.Application.Features.Orders.Queries;
public sealed class GetOrdersQuery : IRequest<IReadOnlyList<OrderResponse>>
{
    public string UserName { get; set; }
}
