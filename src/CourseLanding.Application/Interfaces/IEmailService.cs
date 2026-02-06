namespace CourseLanding.Application.Interfaces;

public interface IEmailService
{
    Task SendHtmlAsync(string to, string subject, string htmlBody, CancellationToken ct = default);
}
