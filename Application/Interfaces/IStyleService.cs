using atk_api.Application.Dtos;
using atk_api.Domain.Interfaces;

namespace atk_api.Application.Interfaces;

public interface IStyleService
{ 
    Task<IEnumerable<StyleDto>> GetAllAsync();
}