namespace Order.Application.Features.Orders.Commands.UpdateOrder;
public sealed class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
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
