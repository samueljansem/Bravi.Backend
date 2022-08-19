namespace Bravi.Backend.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> ListAsync();
    Task<TEntity?> FindAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity, Guid id);
    Task DeleteAsync(Guid id);
}