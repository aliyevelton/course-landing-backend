namespace CourseLanding.Application.DTOs;

public record CreateModuleRequest(
    Guid CourseId,
    string Title,
    string? Description = null,
    int Order = 0
);
