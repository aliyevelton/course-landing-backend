namespace CourseLanding.Application.DTOs;

public record CourseDto(
    Guid Id,
    string Slug,
    string Title,
    string? Subtitle,
    string? Description,
    string? Level,
    string? Language,
    int DurationHours,
    bool IsPublished,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
