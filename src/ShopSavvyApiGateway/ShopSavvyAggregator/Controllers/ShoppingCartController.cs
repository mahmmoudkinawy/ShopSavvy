namespace ShopSavvyAggregator.Controllers;

[Route("api/v{version:apiVersion}/shoppingCart")]
[ApiController]
[ApiVersion("1.0")]
public sealed class ShoppingCartController : ControllerBase
{
    private readonly ICatalogService _catalogService;
    private readonly IBasketService _basketService;
    private readonly IOrderService _orderService;

    public ShoppingCartController(
        ICatalogService catalogService,
        IBasketService basketService,
        IOrderService orderService)
    {
        _catalogService = catalogService ??
            throw new ArgumentNullException(nameof(catalogService));
        _basketService = basketService ??
            throw new ArgumentNullException(nameof(basketService));
        _orderService = orderService ??
            throw new ArgumentNullException(nameof(orderService));
    }

    [HttpGet("{userName}")]
    public async Task<IActionResult> GetShoppingCart(
        [FromRoute] string userName)
    {
        var basket = await _basketService.GetBasketByUserNameAsync(userName);

        if (!basket.Items.Any())
        {
            return NotFound();
        }

        foreach (var item in basket.Items)
        {
            var catalog = await _catalogService.GetCatalogByIdAsync(item.ProductId);

            if (catalog is not null)
            {
                item.ProductName = catalog.Name;
                item.Category = catalog.Category;
                item.Summary = catalog.Summary;
                item.Description = catalog.Description;
                item.ImageFile = catalog.ImageFile;
            }
        }

        var orders = await _orderService.GetOrdersByUserNameAsync(userName);

        return Ok(new ShoppingCartResponse
        {
            UserName = userName,
            Basket = basket,
            Orders = orders
        });
    }

}
