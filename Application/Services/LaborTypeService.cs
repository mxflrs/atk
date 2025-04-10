using System.ComponentModel.DataAnnotations;
using atk_api.Application.Dtos.Requests;
using atk_api.Application.Dtos.Responses;
using atk_api.Application.Interfaces;
using atk_api.Domain.Entities;
using atk_api.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace atk_api.Application.Services;

public class LaborTypeService : IBaseService<LaborTypeDto, UpsertLaborTypeRequest>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public LaborTypeService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LaborTypeDto>> GetAllAsync()
    {
        var laborTypes = await _context.LaborTypes.ToListAsync();
        return _mapper.Map<IEnumerable<LaborTypeDto>>(laborTypes);
    }

    public async Task<LaborTypeDto?> GetByIdAsync(Guid id)
    {
        var laborType = await _context.LaborTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (laborType == null)
        {
            throw new ValidationException("LaborType not found");
        }
        
        return _mapper.Map<LaborTypeDto>(laborType);
    }

    public async Task<LaborTypeDto> CreateAsync(UpsertLaborTypeRequest request)
    {
        bool nameExists = await _context.LaborTypes.AnyAsync(x => x.Title.ToLower() == request.Title.ToLower());

        if (nameExists)
        {
            throw new ValidationException("Title already exists");
        }
        
        var laborType = _mapper.Map<LaborType>(request);
        await _context.LaborTypes.AddAsync(laborType);
        await _context.SaveChangesAsync();
        return _mapper.Map<LaborTypeDto>(laborType);
    }

    public async Task<LaborTypeDto> UpdateAsync(Guid id, UpsertLaborTypeRequest request)
    {
        var laborType = await _context.LaborTypes.FirstOrDefaultAsync(x => x.Id == id);
        bool nameExists = await _context.LaborTypes.AnyAsync(x => x.Title.ToLower() == request.Title.ToLower() && x.Id != id);

        if (laborType == null)
        {
            throw new ValidationException("LaborType does not exists");
        }

        if (nameExists)
        {
            throw new ValidationException("Title already exists");
        }
        
        _mapper.Map(request, laborType);
        await _context.SaveChangesAsync();
        return _mapper.Map<LaborTypeDto>(laborType);
    }

    public async Task DeleteAsync(Guid id)
    {
        var laborType = await _context.LaborTypes.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new ValidationException("LaborType not found");

        try
        {
            _context.LaborTypes.Remove(laborType);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new ValidationException("Failed to delete labortype", ex);
        }
    }
}