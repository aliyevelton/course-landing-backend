using System.Text.Json;
using CourseLanding.Application.DTOs;
using CourseLanding.Application.Interfaces;

namespace CourseLanding.Application.UseCases;

public class GetCourseSections
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseSections(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IReadOnlyList<SectionDto>> ExecuteAsync(string slug, CancellationToken ct = default)
    {
        var course = await _courseRepository.GetBySlugAsync(slug, ct);
        if (course is null) return [];

        var sections = course.Sections
            .Where(s => s.IsActive)
            .OrderBy(s => s.Order)
            .Select(s => new SectionDto(
                s.Id,
                s.Type,
                s.Order,
                s.IsActive,
                ParsePayload(s.Payload)
            ))
            .ToList();

        return sections;
    }

    private static object ParsePayload(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<JsonElement>(json);
        }
        catch
        {
            return new Dictionary<string, object?>();
        }
    }
}
