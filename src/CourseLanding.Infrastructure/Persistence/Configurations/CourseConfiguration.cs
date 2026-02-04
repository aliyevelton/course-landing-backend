using CourseLanding.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseLanding.Infrastructure.Persistence.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Slug)
            .HasMaxLength(200)
            .IsRequired();
        builder.HasIndex(c => c.Slug)
            .IsUnique();

        builder.Property(c => c.Title)
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(c => c.Subtitle).HasMaxLength(500);
        builder.Property(c => c.Description).HasMaxLength(4000);
        builder.Property(c => c.Level).HasMaxLength(50);
        builder.Property(c => c.Language).HasMaxLength(50);
    }
}
