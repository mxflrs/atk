using atk_api.Domain.Entities;

namespace atk_api.Application.Dtos;

public record LaborTypeDto
(Guid Id,
string Title,
DateTime CreatedAt,
DateTime? ModifiedAt,
string Description,
decimal RateMultiplier,
bool Active);