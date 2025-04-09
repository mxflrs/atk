using System.ComponentModel.DataAnnotations;
using atk_api.Application.Common.Exceptions;
using atk_api.Application.Dtos;
using atk_api.Application.Interfaces;
using atk_api.Domain.Entities;
using atk_api.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace atk_api.Application.Services;

public class StyleService: IBaseService<StyleDto, UpsertStyleDto>
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

    public async Task<StyleDto?> GetByIdAsync(Guid id)
    {
        var style = await _context.Styles.FirstOrDefaultAsync(s => s.Id == id);
        
        if (style == null)
        {
            throw new ValidationException($"Material with id: {id} not found");
        }
        
        return _mapper.Map<StyleDto>(style);
    }
    
    public async Task<StyleDto> CreateAsync(UpsertStyleDto dto)
    {
        bool nameExists = await _context.Styles.AnyAsync(x => x.Title.ToLower() == dto.Title.ToLower());

        if (nameExists)
        {
            throw new ValidationException("Title already exists");
        }
        
        var style = _mapper.Map<Style>(dto);
        await _context.Styles.AddAsync(style);
        await _context.SaveChangesAsync();
        return _mapper.Map<StyleDto>(style);
    }

    public async Task<StyleDto> UpdateAsync(Guid id, UpsertStyleDto dto)
    {

        var existingStyle = await _context.Styles.FindAsync(id);

        if (existingStyle == null)
        {
            throw new NotFoundException(nameof(Style), id);
        }

        if (existingStyle.Title.ToLower() == dto.Title.ToLower())
        {
            throw new ValidationException("Title already exists");
        }
        _mapper.Map(dto, existingStyle);
        await _context.SaveChangesAsync();
        return _mapper.Map<StyleDto>(existingStyle);
    }

    public async Task DeleteAsync(Guid id)
    {
        var style = await _context.Styles.FindAsync(id)
            ?? throw new NotFoundException(nameof(Style), id);

        try
        {
            _context.Styles.Remove(style);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.Message);
        }
    }
}