using atk_api.Application.Dtos;
using atk_api.Application.Interfaces;
using atk_api.Domain.Interfaces;
using atk_api.Infrastructure.Persistence;
using AutoMapper;

namespace atk_api.Application.Services;

public class StyleService: IStyleService
{
    private readonly IStyleRepository _repository;
    private readonly IMapper _mapper;

    public StyleService(IStyleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StyleDto>> GetAllAsync()
    {
        var styles = await _repository.GetStylesAsync();
        return _mapper.Map<IEnumerable<StyleDto>>(styles);
    }
}