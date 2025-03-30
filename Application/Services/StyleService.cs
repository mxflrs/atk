using atk_api.Application.Dtos;
using atk_api.Application.Interfaces;
using atk_api.Domain.Entities;
using atk_api.Domain.Interfaces;
using atk_api.Infrastructure.Persistence;
using AutoMapper;

namespace atk_api.Application.Services;

public class StyleService: IStyleService
{
    private readonly IRepository<StyleDto> _repository;
    private readonly IMapper _mapper;

    public StyleService(IRepository<StyleDto> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StyleDto>> GetAllAsync()
    {
        var styles = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<StyleDto>>(styles);
    }

    public async Task<StyleDto?> GetByIdAsync(Guid id)
    {
        var style = await _repository.GetByIdAsync(id);
        return _mapper.Map<StyleDto>(style);
    }
}