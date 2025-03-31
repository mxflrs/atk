using atk_api.Application.Dtos;
using atk_api.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace atk_api.Application.Interfaces;

public interface IStyleService
{ 
    Task<StyleDto> GetByIdAsync(Guid id);
    Task<IEnumerable<StyleDto>> GetAllAsync();
    Task<StyleDto> CreateAsync(CreateStyleDto dto);
    // Task UpdateAsync(Guid id, UpdateStyleDto dto);
    // Task DeleteAsync(Guid id);
}