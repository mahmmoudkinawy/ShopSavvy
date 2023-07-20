namespace Basket.API.Models;
public sealed class CartModel
{
    public string UserName { get; set; }
    public ICollection<CartItemModel> Items { get; set; } = new List<CartItemModel>();

    // Will be replaced in the future
    public decimal TotalPrice
    {
        get
        {
            decimal totalPrice = 0;
            foreach (var item in Items)
            {
                totalPrice += item.Price * item.Quantity;
            }

            return totalPrice;
        }
    }

}
