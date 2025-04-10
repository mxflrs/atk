namespace atk_api.Application.Dtos;

public record MediumDto
(
    Guid Id,
    string Title,
    DateTime CreatedAt,
    DateTime? ModifiedAt
);