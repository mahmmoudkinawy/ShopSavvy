namespace Basket.API.Mappers;
public static class BasketCheckoutMapper
{
    public static BasketCheckoutEvent MapToBasketCheckoutEvent(
        this BasketCheckoutModel basketCheckout)
    {
        return new BasketCheckoutEvent
        {
            AddressLine = basketCheckout.AddressLine,
            CardName = basketCheckout.CardName,
            CardNumber = basketCheckout.CardNumber,
            Country = basketCheckout.Country,
            EmailAddress = basketCheckout.EmailAddress,
            CVV = basketCheckout.CVV,
            Expiration = basketCheckout.Expiration,
            FirstName = basketCheckout.FirstName,
            LastName = basketCheckout.LastName,
            PaymentMethod = basketCheckout.PaymentMethod,
            State = basketCheckout.State,
            TotalPrice = basketCheckout.TotalPrice,
            UserName = basketCheckout.UserName,
            ZipCode = basketCheckout.ZipCode
        };
    }
}
