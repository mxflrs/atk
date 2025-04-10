namespace atk_api.Application.Dtos.Responses;

public record MediumDto
(
    Guid Id,
    string Title,
    DateTime CreatedAt,
    DateTime? ModifiedAt
);