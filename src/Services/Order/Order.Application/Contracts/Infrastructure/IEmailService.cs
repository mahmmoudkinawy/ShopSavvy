namespace Order.Application.Contracts.Infrastructure;
public interface IEmailService
{
    Task<bool> SendEmailAsync(string to, string subject, string body);
}
