namespace CourseLanding.Application.DTOs;

public record UpdateCourseRequest(
    string? Slug = null,
    string? Title = null,
    string? Subtitle = null,
    string? Description = null,
    string? Level = null,
    string? Language = null,
    int? DurationHours = null,
    bool? IsPublished = null
);
