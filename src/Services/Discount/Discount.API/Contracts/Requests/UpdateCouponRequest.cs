namespace Discount.API.Contracts.Requests;
public sealed class UpdateCouponRequest
{
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}
