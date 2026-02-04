namespace CourseLanding.Application.DTOs.SectionPayloads;

public record ProjectsPayload(
    string? Title = null,
    string? Description = null,
    IReadOnlyList<ProjectItem>? Items = null
);

public record ProjectItem(string Title, string? Description = null);
