namespace ShopSavvyAggregator.Contracts.Responses;
public sealed class OrderResponse
{
    public decimal TotalPrice { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string AddressLine { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public int PaymentMethod { get; set; }
}
