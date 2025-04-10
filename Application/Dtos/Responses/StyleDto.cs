namespace atk_api.Application.Dtos.Responses;

public record StyleDto
(
  Guid Id,
  string Title,
  DateTime CreatedAt,
  DateTime? ModifiedAt,
  int Position
);