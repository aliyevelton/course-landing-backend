namespace CourseLanding.Application.DTOs;

public record SubscribeLeadRequest(string Email, string? Name = null, string? Source = null);
