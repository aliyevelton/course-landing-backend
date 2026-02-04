using CourseLanding.Application.DTOs;
using CourseLanding.Application.Interfaces;
using CourseLanding.Domain.Entities;
using CourseLanding.Domain.Enums;

namespace CourseLanding.Application.UseCases;

public class CreateSection
{
    private readonly ICourseRepository _courseRepository;

    public CreateSection(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<SectionDto?> ExecuteAsync(CreateSectionRequest request, CancellationToken ct = default)
    {
        var course = await _courseRepository.GetByIdAsync(request.CourseId, ct);
        if (course is null) return null;

        var section = new Section
        {
            Id = Guid.NewGuid(),
            CourseId = request.CourseId,
            Type = request.Type,
            Order = request.Order,
            IsActive = request.IsActive,
            Payload = request.Payload
        };

        course.Sections.Add(section);
        await _courseRepository.UpdateAsync(course, ct);

        return new SectionDto(
            section.Id,
            section.Type,
            section.Order,
            section.IsActive,
            System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(section.Payload)
        );
    }
}
