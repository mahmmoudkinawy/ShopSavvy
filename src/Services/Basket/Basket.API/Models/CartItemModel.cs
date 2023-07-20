namespace Basket.API.Models;
public sealed class CartItemModel
{
    public int Quantity { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public string ProductName { get; set; }
    public string ProductId { get; set; }
}
