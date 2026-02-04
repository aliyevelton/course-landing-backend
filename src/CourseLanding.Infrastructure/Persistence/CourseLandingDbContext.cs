using CourseLanding.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseLanding.Infrastructure.Persistence;

public class CourseLandingDbContext : DbContext
{
    public CourseLandingDbContext(DbContextOptions<CourseLandingDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<CurriculumModule> CurriculumModules => Set<CurriculumModule>();
    public DbSet<CurriculumLesson> CurriculumLessons => Set<CurriculumLesson>();
    public DbSet<PricingPlan> PricingPlans => Set<PricingPlan>();
    public DbSet<Testimonial> Testimonials => Set<Testimonial>();
    public DbSet<Purchase> Purchases => Set<Purchase>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseLandingDbContext).Assembly);
    }
}
