using CourseLanding.Application.DTOs;
using CourseLanding.Application.Interfaces;
using CourseLanding.Domain.Entities;

namespace CourseLanding.Application.UseCases;

public class CreateCourse
{
    private readonly ICourseRepository _courseRepository;

    public CreateCourse(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto> ExecuteAsync(CreateCourseRequest request, CancellationToken ct = default)
    {
        var course = new Course
        {
            Id = Guid.NewGuid(),
            Slug = request.Slug,
            Title = request.Title,
            Subtitle = request.Subtitle,
            Description = request.Description,
            Level = request.Level,
            Language = request.Language,
            DurationHours = request.DurationHours,
            IsPublished = request.IsPublished,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _courseRepository.AddAsync(course, ct);
        return MapToDto(course);
    }

    private static CourseDto MapToDto(Course c) => new(
        c.Id, c.Slug, c.Title, c.Subtitle, c.Description,
        c.Level, c.Language, c.DurationHours, c.IsPublished, c.CreatedAt, c.UpdatedAt
    );
}
