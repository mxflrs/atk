namespace atk_api.Application.Dtos;

public record MaterialDto
(
    Guid Id,
    string Title,
    DateTime CreatedAt,
    DateTime? ModifiedAt
);