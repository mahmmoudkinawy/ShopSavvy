﻿namespace Catalog.API.Contracts.Requests;
public sealed class ProductCreateRequest
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
}
