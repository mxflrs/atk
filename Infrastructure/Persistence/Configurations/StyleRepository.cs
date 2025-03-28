using atk_api.Application.Dtos;
using atk_api.Domain.Entities;
using atk_api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace atk_api.Infrastructure.Persistence.Configurations;

public class StyleRepository : IStyleRepository
{
    private readonly ApplicationDbContext _context;

    public StyleRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Style>> GetStylesAsync()
    {
        return await _context.Styles.ToListAsync();
    }
}