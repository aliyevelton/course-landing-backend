using CourseLanding.Domain.Entities;
using CourseLanding.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CourseLanding.Infrastructure.Persistence;

public static class DbSeeder
{
    public static async Task EnsureSeededAsync(this CourseLandingDbContext db, CancellationToken ct = default)
    {
        if (await db.Courses.AnyAsync(ct))
            return;

        var now = DateTime.UtcNow;
        var courseId = Guid.NewGuid();

        var course = new Course
        {
            Id = courseId,
            Slug = "data-structures-algorithms-python",
            Title = "The Complete Data Structures and Algorithms Course in Python",
            Subtitle = "Master DSA from basics to advanced with Python",
            Description = "A comprehensive course covering arrays, linked lists, trees, graphs, sorting, searching, and dynamic programming. Build a strong foundation for technical interviews and real-world problem solving.",
            Level = "Beginner to Advanced",
            Language = "English",
            DurationHours = 45,
            IsPublished = true,
            CreatedAt = now,
            UpdatedAt = now
        };

        db.Courses.Add(course);

        // Sections
        var sections = new[]
        {
            (SectionType.Hero, 0, """{"headline":"Master Data Structures & Algorithms in Python","subheadline":"The most comprehensive course for acing technical interviews and building strong programming foundations","primaryCtaText":"Enroll Now","primaryCtaUrl":"#pricing"}"""),
            (SectionType.TrustMetrics, 1, """{"metrics":[{"label":"Students","value":"50K+"},{"label":"Hours of Content","value":"45+"},{"label":"Exercises","value":"200+"},{"label":"4.8 Rating","value":"4.8/5"}]}"""),
            (SectionType.Audience, 2, """{"title":"Who Is This Course For?","description":"Whether you're preparing for interviews or leveling up your skills","bullets":["Software developers preparing for technical interviews","Computer science students","Self-taught programmers wanting to strengthen fundamentals","Anyone building a career in software engineering"]}"""),
            (SectionType.CurriculumPreview, 3, """{"title":"What You'll Learn","description":"A structured curriculum covering all essential DSA topics","ctaText":"View Full Curriculum"}"""),
            (SectionType.Projects, 4, """{"title":"Hands-On Projects","description":"Apply what you learn with real projects","items":[{"title":"Binary Search Tree Implementation","description":"Build a fully functional BST with insert, delete, and traverse"},{"title":"Graph Traversal Explorer","description":"Visualize BFS and DFS on custom graphs"},{"title":"Dynamic Programming Challenges","description":"Solve classic DP problems step by step"}]}"""),
            (SectionType.Testimonials, 5, """{"title":"What Students Say","subtitle":"Join thousands of satisfied learners"}"""),
            (SectionType.Pricing, 6, """{"title":"Simple, Transparent Pricing","subtitle":"One-time payment, lifetime access"}"""),
            (SectionType.FAQ, 7, """{"title":"Frequently Asked Questions","items":[{"question":"Do I need prior programming experience?","answer":"Basic Python knowledge is recommended. We cover fundamentals but assume you can write simple programs."},{"question":"How long do I have access?","answer":"Lifetime access. Once you enroll, the content is yours forever."},{"question":"Are there any prerequisites?","answer":"Familiarity with Python basics (variables, loops, functions) is helpful."}]}"""),
            (SectionType.PlatformComparison, 8, """{"title":"Why Buy on AppMillers?","subtitle":"Get more value when you learn directly from us instead of Udemy","ourPlatformName":"AppMillers","competitorName":"Udemy","rows":[{"feature":"24/7 Mentorship","onOurPlatform":true,"onCompetitor":false},{"feature":"Exclusive Community","onOurPlatform":true,"onCompetitor":false},{"feature":"Direct Instructor Access","onOurPlatform":true,"onCompetitor":false},{"feature":"Priority Support","onOurPlatform":true,"onCompetitor":false},{"feature":"Lifetime Access","onOurPlatform":true,"onCompetitor":true},{"feature":"Updated Content (instructor-controlled)","onOurPlatform":true,"onCompetitor":false},{"feature":"Certificate of Completion","onOurPlatform":true,"onCompetitor":true}]}"""),
            (SectionType.CTA, 9, """{"headline":"Ready to Master DSA?","subheadline":"Start learning today and ace your next technical interview","ctaText":"Get Started","ctaUrl":"#pricing"}"""),
            (SectionType.ContactUs, 10, """{"title":"Any other questions?","subtitle":"For payment questions or other related questions or if you didn't find a timeslot, please reach out to support@appmillers.com or via below contact form","formTitle":"Contact Us","formSubtitle":"Happy to answer any questions you might have!","email":"support@appmillers.com"}""")
        };

        foreach (var (type, order, payload) in sections)
        {
            db.Sections.Add(new Section
            {
                Id = Guid.NewGuid(),
                CourseId = courseId,
                Type = type,
                Order = order,
                IsActive = true,
                Payload = payload
            });
        }

        // Curriculum
        var mod1Id = Guid.NewGuid();
        var mod2Id = Guid.NewGuid();
        var mod3Id = Guid.NewGuid();

        db.CurriculumModules.AddRange(
            new CurriculumModule { Id = mod1Id, CourseId = courseId, Title = "Introduction & Big O", Description = "Complexity analysis and fundamentals", Order = 0 },
            new CurriculumModule { Id = mod2Id, CourseId = courseId, Title = "Data Structures", Description = "Arrays, Linked Lists, Stacks, Queues, Trees, Graphs", Order = 1 },
            new CurriculumModule { Id = mod3Id, CourseId = courseId, Title = "Algorithms", Description = "Sorting, Searching, Dynamic Programming", Order = 2 }
        );

        db.CurriculumLessons.AddRange(
            new CurriculumLesson { Id = Guid.NewGuid(), ModuleId = mod1Id, Title = "Course Overview", DurationMinutes = 10, Order = 0 },
            new CurriculumLesson { Id = Guid.NewGuid(), ModuleId = mod1Id, Title = "Big O Notation", DurationMinutes = 25, Order = 1 },
            new CurriculumLesson { Id = Guid.NewGuid(), ModuleId = mod1Id, Title = "Space & Time Complexity", DurationMinutes = 30, Order = 2 },
            new CurriculumLesson { Id = Guid.NewGuid(), ModuleId = mod2Id, Title = "Arrays & Strings", DurationMinutes = 45, Order = 0 },
            new CurriculumLesson { Id = Guid.NewGuid(), ModuleId = mod2Id, Title = "Linked Lists", DurationMinutes = 60, Order = 1 },
            new CurriculumLesson { Id = Guid.NewGuid(), ModuleId = mod2Id, Title = "Stacks & Queues", DurationMinutes = 40, Order = 2 },
            new CurriculumLesson { Id = Guid.NewGuid(), ModuleId = mod2Id, Title = "Trees & BST", DurationMinutes = 90, Order = 3 },
            new CurriculumLesson { Id = Guid.NewGuid(), ModuleId = mod2Id, Title = "Graphs", DurationMinutes = 75, Order = 4 },
            new CurriculumLesson { Id = Guid.NewGuid(), ModuleId = mod3Id, Title = "Sorting Algorithms", DurationMinutes = 55, Order = 0 },
            new CurriculumLesson { Id = Guid.NewGuid(), ModuleId = mod3Id, Title = "Search Algorithms", DurationMinutes = 40, Order = 1 },
            new CurriculumLesson { Id = Guid.NewGuid(), ModuleId = mod3Id, Title = "Dynamic Programming", DurationMinutes = 120, Order = 2 }
        );

        // Pricing
        db.PricingPlans.AddRange(
            new PricingPlan
            {
                Id = Guid.NewGuid(),
                CourseId = courseId,
                Title = "Full Course Access",
                Price = 49.99m,
                Currency = "USD",
                Features = """["45+ hours of video content","200+ coding exercises","Lifetime access","Certificate of completion","Q&A support"]""",
                StripePriceId = null,
                IsPopular = true,
                IsActive = true
            }
        );

        // Testimonials
        db.Testimonials.AddRange(
            new Testimonial { Id = Guid.NewGuid(), CourseId = courseId, Name = "Sarah K.", Role = "Software Engineer", Quote = "This course helped me land my dream job. The explanations are crystal clear and the exercises are exactly what interviewers ask.", AvatarUrl = null, IsVerified = true },
            new Testimonial { Id = Guid.NewGuid(), CourseId = courseId, Name = "Mike R.", Role = "CS Student", Quote = "Finally understand Big O and dynamic programming. Worth every penny.", AvatarUrl = null, IsVerified = true },
            new Testimonial { Id = Guid.NewGuid(), CourseId = courseId, Name = "Jennifer L.", Role = "Career Switcher", Quote = "Coming from a non-CS background, this course made DSA approachable. Highly recommend.", AvatarUrl = null, IsVerified = false }
        );

        await db.SaveChangesAsync(ct);
    }

    public static async Task EnsureMissingSectionsAsync(this CourseLandingDbContext db, CancellationToken ct = default)
    {
        var course = await db.Courses
            .Include(c => c.Sections)
            .FirstOrDefaultAsync(c => c.Slug == "data-structures-algorithms-python", ct);
        if (course is null) return;

        var contactUsPayload = """{"title":"Any other questions?","subtitle":"For payment questions or other related questions or if you didn't find a timeslot, please reach out to support@appmillers.com or via below contact form","formTitle":"Contact Us","formSubtitle":"Happy to answer any questions you might have!","email":"support@appmillers.com"}""";
        var contactUsSection = course.Sections.FirstOrDefault(s => s.Type == SectionType.ContactUs);
        var shouldSave = false;
        if (contactUsSection is null)
        {
            db.Sections.Add(new Section
            {
                Id = Guid.NewGuid(),
                CourseId = course.Id,
                Type = SectionType.ContactUs,
                Order = 10,
                IsActive = true,
                Payload = contactUsPayload
            });
            shouldSave = true;
        }
        else if (!contactUsSection.Payload.Contains("formTitle"))
        {
            contactUsSection.Payload = contactUsPayload;
            shouldSave = true;
        }
        if (shouldSave)
            await db.SaveChangesAsync(ct);
    }
}
