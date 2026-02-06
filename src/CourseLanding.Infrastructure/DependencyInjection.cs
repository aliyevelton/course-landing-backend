using CourseLanding.Application.Interfaces;
using CourseLanding.Infrastructure.Email;
using CourseLanding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseLanding.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<CourseLandingDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.Configure<SmtpOptions>(configuration.GetSection(SmtpOptions.SectionName));
        services.AddScoped<IEmailService, SmtpEmailService>();

        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ILeadRepository, LeadRepository>();

        return services;
    }
}
