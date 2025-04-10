namespace atk_api.Application.Dtos.Responses;

public record MaterialDto
(
    Guid Id,
    string Title,
    DateTime CreatedAt,
    DateTime? ModifiedAt
);