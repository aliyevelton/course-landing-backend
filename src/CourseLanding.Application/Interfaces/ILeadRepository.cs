using CourseLanding.Domain.Entities;

namespace CourseLanding.Application.Interfaces;

public interface ILeadRepository
{
    Task<bool> ExistsAsync(Guid courseId, string email, CancellationToken ct = default);
    Task<Lead> AddAsync(Lead lead, CancellationToken ct = default);
}
