namespace CourseLanding.Application.DTOs.SectionPayloads;

public record AudiencePayload(
    string? Title = null,
    string? Description = null,
    IReadOnlyList<string>? Bullets = null
);
