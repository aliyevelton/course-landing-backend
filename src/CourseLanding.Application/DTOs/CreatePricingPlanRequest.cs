namespace CourseLanding.Application.DTOs;

public record CreatePricingPlanRequest(
    Guid CourseId,
    string Title,
    decimal Price,
    string Currency = "USD",
    IReadOnlyList<string>? Features = null,
    string? StripePriceId = null,
    bool IsPopular = false,
    bool IsActive = true
);
