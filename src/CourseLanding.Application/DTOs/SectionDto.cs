using CourseLanding.Domain.Enums;

namespace CourseLanding.Application.DTOs;

public record SectionDto(
    Guid Id,
    SectionType Type,
    int Order,
    bool IsActive,
    object Payload
);
