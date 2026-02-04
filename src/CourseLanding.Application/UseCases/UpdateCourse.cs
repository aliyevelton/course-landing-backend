using CourseLanding.Application.DTOs;
using CourseLanding.Application.Interfaces;

namespace CourseLanding.Application.UseCases;

public class UpdateCourse
{
    private readonly ICourseRepository _courseRepository;

    public UpdateCourse(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto?> ExecuteAsync(Guid id, UpdateCourseRequest request, CancellationToken ct = default)
    {
        var course = await _courseRepository.GetByIdAsync(id, ct);
        if (course is null) return null;

        if (request.Slug is not null) course.Slug = request.Slug;
        if (request.Title is not null) course.Title = request.Title;
        if (request.Subtitle is not null) course.Subtitle = request.Subtitle;
        if (request.Description is not null) course.Description = request.Description;
        if (request.Level is not null) course.Level = request.Level;
        if (request.Language is not null) course.Language = request.Language;
        if (request.DurationHours is not null) course.DurationHours = request.DurationHours.Value;
        if (request.IsPublished is not null) course.IsPublished = request.IsPublished.Value;

        course.UpdatedAt = DateTime.UtcNow;
        await _courseRepository.UpdateAsync(course, ct);

        return new CourseDto(
            course.Id, course.Slug, course.Title, course.Subtitle, course.Description,
            course.Level, course.Language, course.DurationHours, course.IsPublished,
            course.CreatedAt, course.UpdatedAt
        );
    }
}
