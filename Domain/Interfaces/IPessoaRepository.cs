using Bravi.Backend.Domain.Entities;

namespace Bravi.Backend.Domain.Interfaces;

public interface IPessoaRepository
{
    Task<IEnumerable<Pessoa>> ObterTodosAsync();
    Task<Pessoa?> ObterAsync(Guid id);
    Task AdicionarAsync(Pessoa pessoa);
    Task AtualizarAsync(Pessoa pessoa);
    Task DeletarAsync(Guid id);
}