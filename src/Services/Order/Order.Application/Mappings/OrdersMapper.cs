namespace Order.Application.Mappings;
public sealed class OrdersMapper : Profile
{
    public OrdersMapper()
    {
        CreateMap<OrderEntity, OrderResponse>();
        CreateMap<CheckoutOrderCommand, OrderEntity>();
        CreateMap<UpdateOrderCommand, OrderEntity>();
    }
}
