namespace atk_api.Application.Interfaces;

public interface IBaseService<TEntity, TUpsertDto> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> CreateAsync(TUpsertDto entity);
    Task<TEntity> UpdateAsync(Guid id, TUpsertDto entity);
    Task DeleteAsync(Guid id);
}