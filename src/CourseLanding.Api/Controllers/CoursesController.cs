using CourseLanding.Application.DTOs;
using CourseLanding.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace CourseLanding.Api.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    [HttpGet("{slug}")]
    public async Task<ActionResult<CourseDto>> GetBySlug(
        string slug,
        [FromServices] GetCourseBySlug useCase,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(slug, ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet("{slug}/sections")]
    public async Task<ActionResult<IReadOnlyList<SectionDto>>> GetSections(
        string slug,
        [FromServices] GetCourseSections useCase,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(slug, ct);
        return Ok(result);
    }

    [HttpGet("{slug}/curriculum")]
    public async Task<ActionResult<CurriculumDto>> GetCurriculum(
        string slug,
        [FromServices] GetCourseCurriculum useCase,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(slug, ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet("{slug}/pricing")]
    public async Task<ActionResult<IReadOnlyList<PricingPlanDto>>> GetPricing(
        string slug,
        [FromServices] GetCoursePricing useCase,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(slug, ct);
        return Ok(result);
    }

    [HttpGet("{slug}/testimonials")]
    public async Task<ActionResult<IReadOnlyList<TestimonialDto>>> GetTestimonials(
        string slug,
        [FromServices] GetCourseTestimonials useCase,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(slug, ct);
        return Ok(result);
    }
}
