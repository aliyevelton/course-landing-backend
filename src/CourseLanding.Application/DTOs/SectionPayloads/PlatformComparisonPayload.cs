namespace CourseLanding.Application.DTOs.SectionPayloads;

public record PlatformComparisonPayload(
    string? Title = null,
    string? Subtitle = null,
    string? OurPlatformName = null,
    string? CompetitorName = null,
    IReadOnlyList<ComparisonRow>? Rows = null
);

public record ComparisonRow(string Feature, bool? OnOurPlatform = null, bool? OnCompetitor = null);
