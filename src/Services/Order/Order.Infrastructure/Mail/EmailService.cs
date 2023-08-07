namespace Order.Infrastructure.Mail;
public sealed class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger ??
            throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> SendEmailAsync(string to, string subject, string body)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(to));
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(subject));
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(body));

        // Send email here using anything like send grid, mailgun, SMTP.

        _logger.LogInformation("Email sent");

        return true;
    }
}
