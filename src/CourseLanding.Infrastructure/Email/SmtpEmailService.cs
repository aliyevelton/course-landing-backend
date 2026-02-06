using CourseLanding.Application.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CourseLanding.Infrastructure.Email;

public class SmtpEmailService : IEmailService
{
    private readonly SmtpOptions _options;
    private readonly ILogger<SmtpEmailService> _logger;

    public SmtpEmailService(IOptions<SmtpOptions> options, ILogger<SmtpEmailService> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    public async Task SendHtmlAsync(string to, string subject, string htmlBody, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(_options.Host))
        {
            _logger.LogWarning("SMTP Host not configured, skipping email to {To}", to);
            return;
        }

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_options.FromName, _options.FromEmail));
        message.To.Add(MailboxAddress.Parse(to));
        message.Subject = subject;

        var builder = new BodyBuilder { HtmlBody = htmlBody };
        message.Body = builder.ToMessageBody();

        using var client = new SmtpClient();
        try
        {
            var secureSocketOptions = _options.UseSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.None;
            await client.ConnectAsync(_options.Host, _options.Port, secureSocketOptions, ct);

            if (!string.IsNullOrEmpty(_options.Username))
                await client.AuthenticateAsync(_options.Username, _options.Password ?? "", ct);

            await client.SendAsync(message, ct);
            _logger.LogInformation("Email sent to {To}", to);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email to {To}", to);
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true, ct);
        }
    }
}
