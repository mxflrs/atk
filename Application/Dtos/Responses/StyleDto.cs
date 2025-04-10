namespace atk_api.Application.Dtos;

public record StyleDto
(
  Guid Id,
  string Title,
  DateTime CreatedAt,
  DateTime? ModifiedAt,
  int Position
);