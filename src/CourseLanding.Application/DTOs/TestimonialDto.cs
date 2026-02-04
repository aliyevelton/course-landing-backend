namespace CourseLanding.Application.DTOs;

public record TestimonialDto(
    Guid Id,
    string Name,
    string? Role,
    string Quote,
    string? AvatarUrl,
    bool IsVerified
);
