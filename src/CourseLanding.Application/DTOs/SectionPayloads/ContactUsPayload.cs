namespace CourseLanding.Application.DTOs.SectionPayloads;

public record ContactUsPayload(
    string? Title = null,
    string? Subtitle = null,
    string? FormTitle = null,
    string? FormSubtitle = null,
    string? Email = null
);
