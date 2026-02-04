using CourseLanding.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseLanding.Infrastructure.Persistence.Configurations;

public class CurriculumModuleConfiguration : IEntityTypeConfiguration<CurriculumModule>
{
    public void Configure(EntityTypeBuilder<CurriculumModule> builder)
    {
        builder.ToTable("CurriculumModules");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Title).HasMaxLength(500).IsRequired();
        builder.Property(m => m.Description).HasMaxLength(2000);

        builder.HasIndex(m => m.CourseId);
        builder.HasOne(m => m.Course)
            .WithMany(c => c.Modules)
            .HasForeignKey(m => m.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
