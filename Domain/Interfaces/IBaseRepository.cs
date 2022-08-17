namespace Bravi.Backend.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity, Guid id);
    Task DeleteAsync(Guid id);
}