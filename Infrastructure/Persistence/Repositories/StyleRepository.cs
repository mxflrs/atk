using atk_api.Application.Dtos;
using atk_api.Domain.Entities;
using atk_api.Domain.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace atk_api.Infrastructure.Persistence.Repositories;

public class StyleRepository : IRepository<StyleDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public StyleRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<StyleDto?> GetByIdAsync(Guid id)
    {
        var style = await _context.Styles.SingleOrDefaultAsync(style => style.Id == id);

        if (style == null)
        {
            return null;
        }
        
        return _mapper.Map<StyleDto>(style);
    }

    public async Task<IEnumerable<StyleDto>> GetAllAsync()
    {
        var styles = await _context.Styles.ToListAsync();
        return _mapper.Map<IEnumerable<StyleDto>>(styles);
    }
}