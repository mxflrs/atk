using atk_api.Application.Common.Exceptions;
using atk_api.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace atk_api.Application.Services;

public abstract class BaseService<TEntity, TUpsertDto> : IBaseService<TEntity, TUpsertDto> where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    
    protected abstract TEntity MapToEntity(TUpsertDto createDto);
    protected abstract void MapToEntity(TUpsertDto updateDto, TEntity entity);

    protected BaseService(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity> CreateAsync(TUpsertDto createDto)
    {
        var entity = MapToEntity(createDto);
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(Guid id, TUpsertDto updateDto)
    {
        var entity = await _dbSet.FindAsync(id) 
                     ?? throw new NotFoundException(typeof(TEntity).Name, id);

        MapToEntity(updateDto, entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id) 
                     ?? throw new NotFoundException(typeof(TEntity).Name, id);
            
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}