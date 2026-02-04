namespace CourseLanding.Application.DTOs.SectionPayloads;

public record CtaPayload(
    string Headline,
    string? Subheadline = null,
    string? CtaText = null,
    string? CtaUrl = null
);
