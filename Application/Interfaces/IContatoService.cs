using Bravi.Backend.Domain.Entities;

namespace Bravi.Backend.Domain.Interfaces;

public interface IContatoService
{
    Task<IEnumerable<Contato>> GetAllAsync(Guid personId);
    Task<Contato?> GetAsync(Guid id);
    Task AddAsync(Contato contato);
    Task UpdateAsync(Contato contato);
    Task DeleteAsync(Guid id);
}