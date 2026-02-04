namespace CourseLanding.Application.DTOs.SectionPayloads;

public record FaqPayload(
    string? Title = null,
    IReadOnlyList<FaqItem>? Items = null
);

public record FaqItem(string Question, string Answer);
