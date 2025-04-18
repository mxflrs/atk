namespace atk_api.Application.Dtos.Responses;

public record SeriesDto(
    Guid Id,
    string Title,
    DateTime CreatedAt,
    DateTime? ModifiedAt
    );