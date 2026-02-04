namespace CourseLanding.Application.DTOs;

public record CurriculumDto(
    IReadOnlyList<CurriculumModuleDto> Modules
);

public record CurriculumModuleDto(
    Guid Id,
    string Title,
    string? Description,
    int Order,
    IReadOnlyList<CurriculumLessonDto> Lessons
);

public record CurriculumLessonDto(
    Guid Id,
    string Title,
    int DurationMinutes,
    int Order
);
