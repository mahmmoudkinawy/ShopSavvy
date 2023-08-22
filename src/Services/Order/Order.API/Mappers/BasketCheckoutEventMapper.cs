namespace Order.API.Mappers;
public static class BasketCheckoutEventMapper
{
    public static CheckoutOrderCommand MapToCheckoutOrderCommand(
        this BasketCheckoutEvent basketCheckoutEvent)
    {
        return new CheckoutOrderCommand
        {
            AddressLine = basketCheckoutEvent.AddressLine,
            CardName = basketCheckoutEvent.CardName,
            CardNumber = basketCheckoutEvent.CardNumber,
            Country = basketCheckoutEvent.Country,
            CVV = basketCheckoutEvent.CVV,
            EmailAddress = basketCheckoutEvent.EmailAddress,
            Expiration = basketCheckoutEvent.Expiration,
            FirstName = basketCheckoutEvent.FirstName,
            LastName = basketCheckoutEvent.LastName,
            PaymentMethod = basketCheckoutEvent.PaymentMethod.Value,
            State = basketCheckoutEvent.State,
            TotalPrice = basketCheckoutEvent.TotalPrice.Value,
            UserName = basketCheckoutEvent.UserName,
            ZipCode = basketCheckoutEvent.ZipCode
        };
    }
}
