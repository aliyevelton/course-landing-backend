namespace CourseLanding.Application.DTOs;

public record CreateCourseRequest(
    string Slug,
    string Title,
    string? Subtitle = null,
    string? Description = null,
    string? Level = null,
    string? Language = null,
    int DurationHours = 0,
    bool IsPublished = false
);
