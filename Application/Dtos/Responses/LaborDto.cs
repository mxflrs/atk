namespace atk_api.Application.Dtos.Responses;

public record LaborDto(
    Guid Id,
    string Title,
    DateTime CreatedAt,
    DateTime? ModifiedAt,
    int Hours,
    Guid TypeId
    );