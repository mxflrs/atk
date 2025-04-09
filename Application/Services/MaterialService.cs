using System.ComponentModel.DataAnnotations;
using atk_api.Application.Dtos;
using atk_api.Application.Interfaces;
using atk_api.Domain.Entities;
using atk_api.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace atk_api.Application.Services;

public class MaterialService : IBaseService<MaterialDto, UpsertMaterialDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public MaterialService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MaterialDto>> GetAllAsync()
    {
        var result = await _context.Materials.ToListAsync();
        return _mapper.Map<IEnumerable<MaterialDto>>(result);
    }

    public async Task<MaterialDto?> GetByIdAsync(Guid id)
    {
        var result = await _context.Materials.FirstOrDefaultAsync(x => x.Id == id);

        if (result == null)
        {
            throw new ValidationException($"Material with id: {id} not found");
        }
        
        return _mapper.Map<MaterialDto>(result);
    }

    public async Task<MaterialDto> CreateAsync(UpsertMaterialDto dto)
    {
        bool nameExists = await _context.Materials.AnyAsync(x => x.Title.ToLower() == dto.Title.ToLower());

        if (nameExists)
        {
            throw new ValidationException("Title already exists");
        }
        
        var material = _mapper.Map<Material>(dto);
        await _context.Materials.AddAsync(material);
        await _context.SaveChangesAsync();
        return _mapper.Map<MaterialDto>(material);
    }

    public async Task<MaterialDto> UpdateAsync(Guid id, UpsertMaterialDto dto)
    {
        var material = await _context.Materials.FirstOrDefaultAsync(x => x.Id == id);
        bool nameExists = await _context.Materials.AnyAsync(x => x.Title.ToLower() == dto.Title.ToLower() && x.Id != id);

        if (material == null)
        {
            throw new ValidationException("Material does not exists");
        }

        if (nameExists)
        {
            throw new ValidationException("Title already exists");
        }
        
        _mapper.Map(dto, material);
        await _context.SaveChangesAsync();
        return _mapper.Map<MaterialDto>(material);
    }

    public async Task DeleteAsync(Guid id)
    {
        var material = _context.Materials.FirstOrDefault(x => x.Id == id)
            ?? throw new ValidationException("Material does not exists");

        try
        {
            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new ValidationException("Failed to delete material", ex);
        }
    }
}