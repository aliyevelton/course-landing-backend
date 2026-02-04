using CourseLanding.Application.DTOs;
using CourseLanding.Application.Interfaces;
using CourseLanding.Domain.Entities;

namespace CourseLanding.Application.UseCases;

public class CreateModule
{
    private readonly ICourseRepository _courseRepository;

    public CreateModule(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CurriculumModuleDto?> ExecuteAsync(CreateModuleRequest request, CancellationToken ct = default)
    {
        var course = await _courseRepository.GetByIdAsync(request.CourseId, ct);
        if (course is null) return null;

        var module = new CurriculumModule
        {
            Id = Guid.NewGuid(),
            CourseId = request.CourseId,
            Title = request.Title,
            Description = request.Description,
            Order = request.Order
        };

        course.Modules.Add(module);
        await _courseRepository.UpdateAsync(course, ct);

        return new CurriculumModuleDto(module.Id, module.Title, module.Description, module.Order, []);
    }
}
