using Bravi.Backend.Data.Context;
using Bravi.Backend.Domain.Entities;
using Bravi.Backend.Domain.Interfaces;

namespace Bravi.Backend.Data.Repositories;

public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
{
    public ContatoRepository(BraviDbContext context) : base(context) { }

    public async Task AdicionarAsync(Contato contato)
    {
        await base.AddAsync(contato);
    }

    public async Task AtualizarAsync(Contato contato)
    {
        await base.UpdateAsync(contato, contato.Id);
    }

    public async Task DeletarAsync(Guid id)
    {
        await base.DeleteAsync(id);
    }

    public async Task<Contato?> ObterAsync(Guid id)
    {
        return await base.GetAsync(id);
    }

    public async Task<IEnumerable<Contato>> ObterTodosAsync(Guid personId)
    {
        var contacts = await base.GetAllAsync();
        return contacts.Where(x => x.PessoaId == personId);
    }
}