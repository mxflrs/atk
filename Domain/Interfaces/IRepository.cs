using atk_api.Domain.Entities;

namespace atk_api.Domain.Interfaces;

public interface IRepository<T>
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    // Task AddAsync(T entity);
    // Task UpdateAsync(T entity);
    // Task DeleteAsync(Guid id);
    //
    // Task<bool> ExistsAsync(Guid id);
    // IQueryable<T> AsQueryable();
}