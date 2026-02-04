namespace CourseLanding.Application.DTOs;

public record CreateLessonRequest(
    Guid ModuleId,
    string Title,
    int DurationMinutes = 0,
    int Order = 0
);
