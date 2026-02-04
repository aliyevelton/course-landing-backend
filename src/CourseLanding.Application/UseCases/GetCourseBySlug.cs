using CourseLanding.Application.DTOs;
using CourseLanding.Application.Interfaces;

namespace CourseLanding.Application.UseCases;

public class GetCourseBySlug
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseBySlug(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto?> ExecuteAsync(string slug, CancellationToken ct = default)
    {
        var course = await _courseRepository.GetBySlugAsync(slug, ct);
        return course is null ? null : MapToDto(course);
    }

    private static CourseDto MapToDto(Domain.Entities.Course c) => new(
        c.Id, c.Slug, c.Title, c.Subtitle, c.Description,
        c.Level, c.Language, c.DurationHours, c.IsPublished, c.CreatedAt, c.UpdatedAt
    );
}
