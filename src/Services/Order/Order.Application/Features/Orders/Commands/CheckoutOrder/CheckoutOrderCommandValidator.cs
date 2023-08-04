namespace Order.Application.Features.Orders.Commands.CheckoutOrder;
public sealed class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidator()
    {
        RuleFor(p => p.UserName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);

        RuleFor(p => p.EmailAddress)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

        RuleFor(p => p.TotalPrice)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}
