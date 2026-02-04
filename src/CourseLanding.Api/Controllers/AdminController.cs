using CourseLanding.Application.DTOs;
using CourseLanding.Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseLanding.Api.Controllers;

[ApiController]
[Route("api/admin")]
[Authorize]
public class AdminController : ControllerBase
{
    [HttpPost("course")]
    public async Task<ActionResult<CourseDto>> CreateCourse(
        [FromBody] CreateCourseRequest request,
        [FromServices] CreateCourse useCase,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(request, ct);
        return CreatedAtAction("GetBySlug", "Courses", new { slug = result.Slug }, result);
    }

    [HttpPut("course/{id:guid}")]
    public async Task<ActionResult<CourseDto>> UpdateCourse(
        Guid id,
        [FromBody] UpdateCourseRequest request,
        [FromServices] UpdateCourse useCase,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(id, request, ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost("section")]
    public async Task<ActionResult<SectionDto>> CreateSection(
        [FromBody] CreateSectionRequest request,
        [FromServices] CreateSection useCase,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(request, ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost("module")]
    public async Task<ActionResult<CurriculumModuleDto>> CreateModule(
        [FromBody] CreateModuleRequest request,
        [FromServices] CreateModule useCase,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(request, ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost("pricing")]
    public async Task<ActionResult<PricingPlanDto>> CreatePricingPlan(
        [FromBody] CreatePricingPlanRequest request,
        [FromServices] CreatePricingPlan useCase,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(request, ct);
        return result is null ? NotFound() : Ok(result);
    }
}
