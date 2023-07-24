namespace Discount.Grpc.Entities;
public sealed class CouponEntity
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}
