namespace CourseLanding.Domain.Entities;

public class PricingPlan
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Currency { get; set; } = "USD";
    public string Features { get; set; } = "[]"; // JSON array of feature strings
    public string? StripePriceId { get; set; }
    public bool IsPopular { get; set; }
    public bool IsActive { get; set; }

    public Course Course { get; set; } = null!;
}
