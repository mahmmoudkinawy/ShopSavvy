namespace ShopSavvyAggregator.Contracts.Responses;
public sealed class BasketResponse
{
    public ICollection<BasketItemResponse> Items { get; set; }
    public decimal TotalPrice { get; set; }
}
