namespace atk_api.Application.Dtos;

public record UpsertLaborTypeRequest
(
    string Title,
    string Description,
    decimal RateMultiplier,
    bool Active
    );