namespace Discount.API.Validations;
public class UpdateCouponValidation : AbstractValidator<UpdateCouponRequest>
{
    public UpdateCouponValidation()
    {
        RuleFor(c => c.ProductName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(c => c.Description)
            .NotEmpty()
            .NotNull()
            .MaximumLength(5000);

        RuleFor(c => c.Amount)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(0);
    }
}
