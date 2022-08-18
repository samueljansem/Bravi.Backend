using Bravi.Backend.Data.Context;
using Bravi.Backend.Domain.Entities;
using Bravi.Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bravi.Backend.Data.Repositories;

public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
{
    private readonly BraviDbContext _context;

    public PessoaRepository(BraviDbContext context) : base(context)
    {
        _context = context;
    }

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
        return await _context.Set<Pessoa>().Include(x => x.Contatos).Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Pessoa>> ObterTodosAsync()
    {
        return await _context.Set<Pessoa>().Include(x => x.Contatos).ToListAsync();
    }
}