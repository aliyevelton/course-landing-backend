namespace CourseLanding.Domain.Entities;

public class CurriculumLesson
{
    public Guid Id { get; set; }
    public Guid ModuleId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public int Order { get; set; }

    public CurriculumModule Module { get; set; } = null!;
}
