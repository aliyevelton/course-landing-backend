using CourseLanding.Application.Interfaces;
using CourseLanding.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseLanding.Infrastructure.Persistence;

public class LeadRepository : ILeadRepository
{
    private readonly CourseLandingDbContext _db;

    public LeadRepository(CourseLandingDbContext db)
    {
        _db = db;
    }

    public async Task<bool> ExistsAsync(Guid courseId, string email, CancellationToken ct = default)
    {
        return await _db.Leads
            .AnyAsync(l => l.CourseId == courseId && l.Email == email, ct);
    }

    public async Task<Lead> AddAsync(Lead lead, CancellationToken ct = default)
    {
        _db.Leads.Add(lead);
        await _db.SaveChangesAsync(ct);
        return lead;
    }
}
