namespace CourseLanding.Domain.Entities;

public class Testimonial
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Role { get; set; }
    public string Quote { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public bool IsVerified { get; set; }

    public Course Course { get; set; } = null!;
}
