using CourseLanding.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseLanding.Infrastructure.Persistence.Configurations;

public class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.ToTable("Leads");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Email).HasMaxLength(320).IsRequired();
        builder.Property(l => l.Name).HasMaxLength(200);
        builder.Property(l => l.Source).HasMaxLength(100);

        builder.HasIndex(l => l.CourseId);
        builder.HasIndex(l => new { l.CourseId, l.Email });
        builder.HasOne(l => l.Course)
            .WithMany(c => c.Leads)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
