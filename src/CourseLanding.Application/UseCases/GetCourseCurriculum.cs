using CourseLanding.Application.DTOs;
using CourseLanding.Application.Interfaces;

namespace CourseLanding.Application.UseCases;

public class GetCourseCurriculum
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseCurriculum(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CurriculumDto?> ExecuteAsync(string slug, CancellationToken ct = default)
    {
        var course = await _courseRepository.GetBySlugAsync(slug, ct);
        if (course is null) return null;

        var modules = course.Modules
            .OrderBy(m => m.Order)
            .Select(m => new CurriculumModuleDto(
                m.Id,
                m.Title,
                m.Description,
                m.Order,
                m.Lessons
                    .OrderBy(l => l.Order)
                    .Select(l => new CurriculumLessonDto(l.Id, l.Title, l.DurationMinutes, l.Order))
                    .ToList()
            ))
            .ToList();

        return new CurriculumDto(modules);
    }
}
