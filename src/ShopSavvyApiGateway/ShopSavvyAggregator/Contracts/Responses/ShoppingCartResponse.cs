namespace ShopSavvyAggregator.Contracts.Responses;
public sealed class ShoppingCartResponse
{
    public string UserName { get; set; }
    public BasketResponse Basket { get; set; }
    public IReadOnlyList<OrderResponse> Orders { get; set; }
}
