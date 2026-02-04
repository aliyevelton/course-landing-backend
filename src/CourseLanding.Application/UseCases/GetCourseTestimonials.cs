using CourseLanding.Application.DTOs;
using CourseLanding.Application.Interfaces;

namespace CourseLanding.Application.UseCases;

public class GetCourseTestimonials
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseTestimonials(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IReadOnlyList<TestimonialDto>> ExecuteAsync(string slug, CancellationToken ct = default)
    {
        var course = await _courseRepository.GetBySlugAsync(slug, ct);
        if (course is null) return [];

        return course.Testimonials
            .Select(t => new TestimonialDto(t.Id, t.Name, t.Role, t.Quote, t.AvatarUrl, t.IsVerified))
            .ToList();
    }
}
