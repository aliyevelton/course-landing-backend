namespace CourseLanding.Application.DTOs;

public record PricingPlanDto(
    Guid Id,
    string Title,
    decimal Price,
    string Currency,
    IReadOnlyList<string> Features,
    bool IsPopular,
    bool IsActive
);
