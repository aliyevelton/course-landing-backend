using System.Text.Json;
using CourseLanding.Application.DTOs;
using CourseLanding.Application.Interfaces;
using CourseLanding.Domain.Entities;

namespace CourseLanding.Application.UseCases;

public class CreatePricingPlan
{
    private readonly ICourseRepository _courseRepository;

    public CreatePricingPlan(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<PricingPlanDto?> ExecuteAsync(CreatePricingPlanRequest request, CancellationToken ct = default)
    {
        var course = await _courseRepository.GetByIdAsync(request.CourseId, ct);
        if (course is null) return null;

        var plan = new PricingPlan
        {
            Id = Guid.NewGuid(),
            CourseId = request.CourseId,
            Title = request.Title,
            Price = request.Price,
            Currency = request.Currency,
            Features = JsonSerializer.Serialize(request.Features ?? Array.Empty<string>()),
            StripePriceId = request.StripePriceId,
            IsPopular = request.IsPopular,
            IsActive = request.IsActive
        };

        course.PricingPlans.Add(plan);
        await _courseRepository.UpdateAsync(course, ct);

        return new PricingPlanDto(
            plan.Id, plan.Title, plan.Price, plan.Currency,
            request.Features ?? Array.Empty<string>(), plan.IsPopular, plan.IsActive
        );
    }
}
