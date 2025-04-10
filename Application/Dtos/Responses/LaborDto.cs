using atk_api.Domain.Entities;

namespace atk_api.Application.Dtos;

public record LaborDto(
    Guid Id,
    string Title,
    DateTime CreatedAt,
    DateTime? ModifiedAt,
    int Hours,
    Guid TypeId
    );