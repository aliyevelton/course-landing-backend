namespace CourseLanding.Application.DTOs.SectionPayloads;

public record TrustMetricsPayload(
    IReadOnlyList<MetricItem> Metrics
);

public record MetricItem(string Label, string Value);
