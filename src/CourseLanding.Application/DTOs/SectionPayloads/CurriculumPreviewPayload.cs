namespace CourseLanding.Application.DTOs.SectionPayloads;

public record CurriculumPreviewPayload(
    string? Title = null,
    string? Description = null,
    string? CtaText = null
);
