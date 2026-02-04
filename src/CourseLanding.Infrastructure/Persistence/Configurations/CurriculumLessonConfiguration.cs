using CourseLanding.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseLanding.Infrastructure.Persistence.Configurations;

public class CurriculumLessonConfiguration : IEntityTypeConfiguration<CurriculumLesson>
{
    public void Configure(EntityTypeBuilder<CurriculumLesson> builder)
    {
        builder.ToTable("CurriculumLessons");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Title).HasMaxLength(500).IsRequired();

        builder.HasIndex(l => l.ModuleId);
        builder.HasOne(l => l.Module)
            .WithMany(m => m.Lessons)
            .HasForeignKey(l => l.ModuleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
