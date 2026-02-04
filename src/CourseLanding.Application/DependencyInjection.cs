using CourseLanding.Application.Interfaces;
using CourseLanding.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace CourseLanding.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetCourseBySlug>();
        services.AddScoped<GetCourseSections>();
        services.AddScoped<GetCourseCurriculum>();
        services.AddScoped<GetCoursePricing>();
        services.AddScoped<GetCourseTestimonials>();
        services.AddScoped<CreateCourse>();
        services.AddScoped<UpdateCourse>();
        services.AddScoped<CreateSection>();
        services.AddScoped<CreateModule>();
        services.AddScoped<CreatePricingPlan>();
        return services;
    }
}
