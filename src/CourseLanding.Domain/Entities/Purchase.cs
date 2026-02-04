namespace CourseLanding.Domain.Entities;

public class Purchase
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public string StripeSessionId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public DateTime CreatedAt { get; set; }

    public Course Course { get; set; } = null!;
}
