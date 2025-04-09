namespace atk_api.Application.Dtos;

public record SeriesDto(
    Guid Id,
    string Title,
    DateTime CreatedAt,
    DateTime? ModifiedAt
    );