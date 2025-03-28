using atk_api.Application.Dtos;
using atk_api.Domain.Entities;

namespace atk_api.Domain.Interfaces;

public interface IStyleRepository
{
   Task<IEnumerable<Style>> GetStylesAsync();
}