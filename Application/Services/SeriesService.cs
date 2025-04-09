using System.ComponentModel.DataAnnotations;
using atk_api.Application.Dtos;
using atk_api.Application.Interfaces;
using atk_api.Domain.Entities;
using atk_api.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace atk_api.Application.Services;

public class SeriesService : IBaseService<SeriesDto, UpsertSeriesDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public SeriesService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SeriesDto>> GetAllAsync()
    {
        var series = await _context.Series.ToListAsync();
        return _mapper.Map<IEnumerable<SeriesDto>>(series);
    }
    
    public async Task<SeriesDto?> GetByIdAsync(Guid id)
    {
        var series = await _context.Series.FindAsync(id);
        
        if (series == null)
        {
            throw new ValidationException($"Material with id: {id} not found");
        }
        
        return _mapper.Map<SeriesDto>(series);
    }

    public async Task<SeriesDto> CreateAsync(UpsertSeriesDto dto)
    {
        bool nameExists = await _context.Series.AnyAsync(x => x.Title.ToLower() == dto.Title.ToLower());

        if (nameExists)
        {
            throw new ValidationException("Title already exists");
        }
        
        var series = _mapper.Map<Series>(dto);
        await _context.Series.AddAsync(series);
        await _context.SaveChangesAsync();
        return _mapper.Map<SeriesDto>(series);
    }

    public async Task<SeriesDto> UpdateAsync(Guid id, UpsertSeriesDto dto)
    {
        var series = await _context.Series.FindAsync(id);
        bool nameExists = await _context.Series.AnyAsync(x => x.Title.ToLower() == dto.Title.ToLower() && x.Id != id);

        if (series == null)
        {
            throw new ValidationException("Series does not exist");
        }

        if (nameExists)
        {
            throw new ValidationException("Title already exists");
        }
        
        _mapper.Map(dto, series);
        await _context.SaveChangesAsync();
        return _mapper.Map<SeriesDto>(series);
    }

    public async Task DeleteAsync(Guid id)
    {
        var series = await _context.Series.FindAsync(id)
            ?? throw new ValidationException("Series does not exist");

        try
        {
            _context.Series.Remove(series);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new ValidationException("Failed to delete series", ex);
        }
    }
}