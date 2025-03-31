using atk_api.Application.Dtos;
using atk_api.Application.Interfaces;
using atk_api.Domain.Entities;
using atk_api.Domain.Interfaces;
using atk_api.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace atk_api.Application.Services;

public class StyleService: IStyleService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public StyleService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StyleDto>> GetAllAsync()
    {
        var styles = await _context.Styles.ToListAsync();
        return _mapper.Map<IEnumerable<StyleDto>>(styles);
    }

    public async Task<StyleDto> GetByIdAsync(Guid id)
    {
        var style = await _context.Styles.FirstOrDefaultAsync(s => s.Id == id);
        return _mapper.Map<StyleDto>(style);
    }
    
    public async Task<StyleDto> CreateAsync(CreateStyleDto dto)
    {
        var style = _mapper.Map<Style>(dto);
        await _context.Styles.AddAsync(style);
        await _context.SaveChangesAsync();
        return _mapper.Map<StyleDto>(style);
    }
}