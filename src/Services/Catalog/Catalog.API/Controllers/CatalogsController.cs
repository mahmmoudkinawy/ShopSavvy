namespace Catalog.API.Controllers;

[Route("api/v{version:apiVersion}/catalogs")]
[ApiVersion("1.0")]
[ApiController]
public sealed class CatalogsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CatalogsController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository ??
            throw new ArgumentNullException(nameof(productRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productRepository.GetProductsAsync();

        return Ok(_mapper.Map<IReadOnlyList<ProductResponse>>(products));
    }

    [HttpGet("by-category-name/{categoryName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductsByCategoryName(
        [FromRoute] string categoryName)
    {
        var products = await _productRepository.GetProductsByCategoryNameAsync(categoryName);

        return Ok(_mapper.Map<IReadOnlyList<ProductResponse>>(products));
    }

    [HttpGet("{productId:length(24)}", Name = "GetProductById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductById(
        [FromRoute] string productId)
    {
        var product = await _productRepository.GetProductByIdAsync(productId);

        if (product is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ProductResponse>(product));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct(
        [FromBody] ProductCreateRequest request)
    {
        var product = _mapper.Map<ProductEntity>(request);

        await _productRepository.CreateProductAsync(product);

        var productToReturn = _mapper.Map<ProductResponse>(product);

        return CreatedAtRoute(nameof(GetProductById), new { productId = productToReturn.Id }, productToReturn);
    }

    [HttpPut("{productId:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct(
        [FromRoute] string productId,
        [FromBody] ProductCreateRequest request)
    {
        var product = await _productRepository.GetProductByIdAsync(productId);

        if (product is null)
        {
            return NotFound();
        }

        _mapper.Map(request, product);

        var result = await _productRepository.UpdateProductAsync(product);

        if (!result)
        {
            return BadRequest("Can not update this product.");
        }

        return NoContent();
    }

    [HttpDelete("{productId:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(
        [FromRoute] string productId)
    {
        if (!await _productRepository.IsProductExistAsync(productId))
        {
            return NotFound();
        }

        var result = await _productRepository.RemoveProductAsync(productId);

        if (!result)
        {
            return BadRequest("Can not delete this product.");
        }

        return NoContent();
    }

}
