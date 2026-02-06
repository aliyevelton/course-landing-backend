using CourseLanding.Application.DTOs;
using CourseLanding.Application.Interfaces;
using CourseLanding.Domain.Entities;

namespace CourseLanding.Application.UseCases;

public class SubscribeLead
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILeadRepository _leadRepository;
    private readonly IEmailService _emailService;

    public SubscribeLead(ICourseRepository courseRepository, ILeadRepository leadRepository, IEmailService emailService)
    {
        _courseRepository = courseRepository;
        _leadRepository = leadRepository;
        _emailService = emailService;
    }

    public async Task<(bool Success, string? Error)> ExecuteAsync(string courseSlug, SubscribeLeadRequest request, CancellationToken ct = default)
    {
        var email = request.Email?.Trim();
        if (string.IsNullOrEmpty(email))
            return (false, "Email is required.");

        if (email.Length > 320)
            return (false, "Invalid email.");

        var course = await _courseRepository.GetBySlugAsync(courseSlug, ct);
        if (course is null)
            return (false, "Course not found.");

        if (await _leadRepository.ExistsAsync(course.Id, email, ct))
            return (true, null); // Idempotent: already subscribed

        var lead = new Lead
        {
            Id = Guid.NewGuid(),
            CourseId = course.Id,
            Email = email,
            Name = string.IsNullOrWhiteSpace(request.Name) ? null : request.Name.Trim(),
            Source = string.IsNullOrWhiteSpace(request.Source) ? null : request.Source.Trim(),
            CreatedAt = DateTime.UtcNow
        };

        await _leadRepository.AddAsync(lead, ct);

        var html = $"""
            <!DOCTYPE html>
            <html>
            <head><meta charset="utf-8"><title>Thanks for subscribing</title></head>
            <body style="font-family: system-ui, sans-serif; line-height: 1.6; color: #333; max-width: 600px; margin: 0 auto; padding: 20px;">
                <h1 style="color: #059669;">Thanks for subscribing!</h1>
                <p>Hi{(string.IsNullOrWhiteSpace(request.Name) ? "" : $" {request.Name.Trim()}")},</p>
                <p>You're on the list. We'll send you the curriculum and updates about <strong>{course.Title}</strong>.</p>
                <p style="color: #6b7280; font-size: 14px;">— The AppMillers Team</p>
            </body>
            </html>
            """;

        try
        {
            await _emailService.SendHtmlAsync(email, $"Welcome — {course.Title}", html, ct);
        }
        catch
        {
            // Lead is saved; email failure shouldn't fail the request
        }

        return (true, null);
    }
}
