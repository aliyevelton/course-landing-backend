namespace CourseLanding.Domain.Entities;

public class CurriculumModule
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Order { get; set; }

    public Course Course { get; set; } = null!;
    public ICollection<CurriculumLesson> Lessons { get; set; } = new List<CurriculumLesson>();
}
