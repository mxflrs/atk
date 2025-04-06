namespace atk_api.Application.Dtos;

public record StyleDto
(
  Guid Id,
  string Title,
  DateTime CreatedAt,
  int Position
);