using System.Text.Json;
using CourseLanding.Application.DTOs;
using CourseLanding.Application.Interfaces;

namespace CourseLanding.Application.UseCases;

public class GetCoursePricing
{
    private readonly ICourseRepository _courseRepository;

    public GetCoursePricing(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IReadOnlyList<PricingPlanDto>> ExecuteAsync(string slug, CancellationToken ct = default)
    {
        var course = await _courseRepository.GetBySlugAsync(slug, ct);
        if (course is null) return [];

        var plans = course.PricingPlans
            .Where(p => p.IsActive)
            .OrderBy(p => p.Price)
            .Select(p => new PricingPlanDto(
                p.Id,
                p.Title,
                p.Price,
                p.Currency,
                ParseFeatures(p.Features),
                p.IsPopular,
                p.IsActive
            ))
            .ToList();

        return plans;
    }

    private static IReadOnlyList<string> ParseFeatures(string json)
    {
        try
        {
            var list = JsonSerializer.Deserialize<List<string>>(json);
            return list ?? [];
        }
        catch
        {
            return [];
        }
    }
}
