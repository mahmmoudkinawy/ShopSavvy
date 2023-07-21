namespace Discount.API.Contracts.Responses;
public sealed class CouponResponse
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}
