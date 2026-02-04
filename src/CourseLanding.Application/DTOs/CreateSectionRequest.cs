using CourseLanding.Domain.Enums;

namespace CourseLanding.Application.DTOs;

public record CreateSectionRequest(
    Guid CourseId,
    SectionType Type,
    int Order,
    bool IsActive = true,
    string Payload = "{}"
);
