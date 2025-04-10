namespace atk_api.Application.Dtos.Requests;

public record UpsertLaborRequest
(
    string Title,
    int Hours,
    Guid LaborTypeId
    );