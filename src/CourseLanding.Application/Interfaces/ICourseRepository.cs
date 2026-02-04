using CourseLanding.Domain.Entities;

namespace CourseLanding.Application.Interfaces;

public interface ICourseRepository
{
    Task<Course?> GetBySlugAsync(string slug, CancellationToken ct = default);
    Task<Course?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<Course> AddAsync(Course course, CancellationToken ct = default);
    Task UpdateAsync(Course course, CancellationToken ct = default);
}
