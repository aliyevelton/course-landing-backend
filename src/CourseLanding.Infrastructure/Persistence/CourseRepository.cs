using CourseLanding.Application.Interfaces;
using CourseLanding.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseLanding.Infrastructure.Persistence;

public class CourseRepository : ICourseRepository
{
    private readonly CourseLandingDbContext _db;

    public CourseRepository(CourseLandingDbContext db)
    {
        _db = db;
    }

    public async Task<Course?> GetBySlugAsync(string slug, CancellationToken ct = default)
    {
        return await _db.Courses
            .AsNoTracking()
            .Include(c => c.Sections)
            .Include(c => c.Modules)
                .ThenInclude(m => m.Lessons)
            .Include(c => c.PricingPlans)
            .Include(c => c.Testimonials)
            .FirstOrDefaultAsync(c => c.Slug == slug && c.IsPublished, ct);
    }

    public async Task<Course?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _db.Courses
            .Include(c => c.Sections)
            .Include(c => c.Modules)
                .ThenInclude(m => m.Lessons)
            .Include(c => c.PricingPlans)
            .Include(c => c.Testimonials)
            .FirstOrDefaultAsync(c => c.Id == id, ct);
    }

    public async Task<Course> AddAsync(Course course, CancellationToken ct = default)
    {
        _db.Courses.Add(course);
        await _db.SaveChangesAsync(ct);
        return course;
    }

    public async Task UpdateAsync(Course course, CancellationToken ct = default)
    {
        await _db.SaveChangesAsync(ct);
    }
}
