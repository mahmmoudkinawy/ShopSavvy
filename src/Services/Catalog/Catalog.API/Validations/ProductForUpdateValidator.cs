namespace Catalog.API.Validations;
public sealed class ProductForUpdateValidator : AbstractValidator<ProductUpdateRequest>
{
    public ProductForUpdateValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.Category)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.ImageFile)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.Description)
            .NotNull()
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(5000);

        RuleFor(p => p.Summary)
            .NotNull()
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(1000);

        RuleFor(p => p.ImageFile)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.Price)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);
    }
}
