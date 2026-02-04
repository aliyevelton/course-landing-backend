namespace CourseLanding.Domain.Entities;

public class Course
{
    public Guid Id { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Subtitle { get; set; }
    public string? Description { get; set; }
    public string? Level { get; set; }
    public string? Language { get; set; }
    public int DurationHours { get; set; }
    public bool IsPublished { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Section> Sections { get; set; } = new List<Section>();
    public ICollection<CurriculumModule> Modules { get; set; } = new List<CurriculumModule>();
    public ICollection<PricingPlan> PricingPlans { get; set; } = new List<PricingPlan>();
    public ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();
    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
