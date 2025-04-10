namespace atk_api.Application.Dtos;

public record UpsertLaborRequest
(
    string Title,
    int Hours,
    Guid LaborTypeId
    );