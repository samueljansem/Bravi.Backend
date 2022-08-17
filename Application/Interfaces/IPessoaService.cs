using Bravi.Backend.Domain.Entities;

namespace Bravi.Backend.Domain.Interfaces;

public interface IPessoaService
{
    Task<IEnumerable<Pessoa>> GetAllAsync();
    Task<Pessoa?> GetAsync(Guid id);
    Task AddAsync(Pessoa pessoa);
    Task UpdateAsync(Pessoa pessoa);
    Task DeleteAsync(Guid id);
}