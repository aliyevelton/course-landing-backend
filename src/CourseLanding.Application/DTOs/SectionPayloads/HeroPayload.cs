namespace CourseLanding.Application.DTOs.SectionPayloads;

public record HeroPayload(
    string Headline,
    string? Subheadline = null,
    string? PrimaryCtaText = null,
    string? PrimaryCtaUrl = null,
    string? BackgroundImageUrl = null
);
