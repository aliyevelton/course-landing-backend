using CourseLanding.Domain.Enums;

namespace CourseLanding.Domain.Entities;

public class Section
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public SectionType Type { get; set; }
    public int Order { get; set; }
    public bool IsActive { get; set; }
    public string Payload { get; set; } = "{}"; // JSON - section-specific content

    public Course Course { get; set; } = null!;
}
