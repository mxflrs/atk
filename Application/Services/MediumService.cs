using System.ComponentModel.DataAnnotations;
using atk_api.Application.Common.Exceptions;
using atk_api.Application.Dtos;
using atk_api.Application.Dtos.Requests;
using atk_api.Application.Dtos.Responses;
using atk_api.Application.Interfaces;
using atk_api.Domain.Entities;
using atk_api.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace atk_api.Application.Services;

public class MediumService : IBaseService<MediumDto, UpsertMediumRequest>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public MediumService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MediumDto>> GetAllAsync()
    {
        var mediums = await _context.Mediums.ToListAsync();
        return _mapper.Map<IEnumerable<MediumDto>>(mediums);
    }

    public async Task<MediumDto?> GetByIdAsync(Guid id)
    {
        var medium = await _context.Mediums.FirstOrDefaultAsync(m => m.Id == id);
        
        if (medium == null)
        {
            throw new ValidationException($"Medium with id: {id} not found");
        }
        
        return _mapper.Map<MediumDto>(medium);
    }

    public async Task<MediumDto> CreateAsync(UpsertMediumRequest request)
    {
        bool nameExists = await _context.Mediums.AnyAsync(x => x.Title.ToLower() == request.Title.ToLower());

        if (nameExists)
        {
            throw new ValidationException("Title already exists");
        }
        
        var medium = _mapper.Map<Medium>(request);
        await _context.Mediums.AddAsync(medium);
        await _context.SaveChangesAsync();
        return _mapper.Map<MediumDto>(medium);
    }

    public async Task<MediumDto> UpdateAsync(Guid id, UpsertMediumRequest request)
    {
        var existingMedium = await _context.Mediums.FirstOrDefaultAsync(m => m.Id == id);

        if (existingMedium == null)
        {
            throw new NotFoundException(nameof(Medium), id);
        }

        if (existingMedium.Title.ToLower() == request.Title.ToLower())
        {
            throw new ValidationException("Title already exists");
        }
        
        _mapper.Map(request, existingMedium);
        await _context.SaveChangesAsync();
        return _mapper.Map<MediumDto>(existingMedium);
    }

    public async Task DeleteAsync(Guid id)
    {
        var medium = await _context.Mediums.FindAsync(id)
            ?? throw new NotFoundException(nameof(Medium), id);

        try
        {
            _context.Mediums.Remove(medium);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.Message);
        }
    }
}