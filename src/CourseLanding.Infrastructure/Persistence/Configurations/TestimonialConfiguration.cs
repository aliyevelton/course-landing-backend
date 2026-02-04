using CourseLanding.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseLanding.Infrastructure.Persistence.Configurations;

public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
{
    public void Configure(EntityTypeBuilder<Testimonial> builder)
    {
        builder.ToTable("Testimonials");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name).HasMaxLength(200).IsRequired();
        builder.Property(t => t.Role).HasMaxLength(200);
        builder.Property(t => t.Quote).HasMaxLength(2000).IsRequired();
        builder.Property(t => t.AvatarUrl).HasMaxLength(500);

        builder.HasIndex(t => t.CourseId);
        builder.HasOne(t => t.Course)
            .WithMany(c => c.Testimonials)
            .HasForeignKey(t => t.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
