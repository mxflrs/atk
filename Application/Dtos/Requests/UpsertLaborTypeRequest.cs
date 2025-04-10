namespace atk_api.Application.Dtos.Requests;

public record UpsertLaborTypeRequest
(
    string Title,
    string Description,
    decimal RateMultiplier,
    bool Active
    );