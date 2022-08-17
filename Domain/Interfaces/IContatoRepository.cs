using Bravi.Backend.Domain.Entities;

namespace Bravi.Backend.Domain.Interfaces;

public interface IContatoRepository
{
    Task<IEnumerable<Contato>> ObterTodosAsync(Guid personId);
    Task<Contato?> ObterAsync(Guid id);
    Task AdicionarAsync(Contato contato);
    Task AtualizarAsync(Contato contato);
    Task DeletarAsync(Guid id);
}