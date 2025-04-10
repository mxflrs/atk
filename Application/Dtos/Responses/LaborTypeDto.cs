namespace atk_api.Application.Dtos.Responses;

public record LaborTypeDto
(Guid Id,
string Title,
DateTime CreatedAt,
DateTime? ModifiedAt,
string Description,
decimal RateMultiplier,
bool Active);