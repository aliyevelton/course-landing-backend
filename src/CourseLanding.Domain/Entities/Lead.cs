namespace CourseLanding.Domain.Entities;

public class Lead
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? Source { get; set; }
    public DateTime CreatedAt { get; set; }

    public Course Course { get; set; } = null!;
}
