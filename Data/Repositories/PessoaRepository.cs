using Bravi.Backend.Data.Context;
using Bravi.Backend.Domain.Entities;
using Bravi.Backend.Domain.Interfaces;

namespace Bravi.Backend.Data.Repositories;

public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
{
    public PessoaRepository(BraviDbContext context) : base(context) { }

    public async Task AdicionarAsync(Pessoa pessoa)
    {
        await base.AddAsync(pessoa);
    }

    public async Task AtualizarAsync(Pessoa pessoa)
    {
        await base.UpdateAsync(pessoa, pessoa.Id);
    }

    public async Task DeletarAsync(Guid id)
    {
        await base.DeleteAsync(id);
    }

    public async Task<Pessoa?> ObterAsync(Guid id)
    {
        return await base.GetAsync(id);
    }

    public async Task<IEnumerable<Pessoa>> ObterTodosAsync()
    {
        return await base.GetAllAsync();
    }
}