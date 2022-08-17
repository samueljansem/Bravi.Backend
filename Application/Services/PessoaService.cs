using Bravi.Backend.Domain.Entities;
using Bravi.Backend.Domain.Interfaces;

namespace Bravi.Backend.Application.Services;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _repository;

    public PessoaService(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(Pessoa pessoa)
    {
        await _repository.AdicionarAsync(pessoa);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeletarAsync(id);
    }

    public async Task<IEnumerable<Pessoa>> GetAllAsync()
    {
        return await _repository.ObterTodosAsync();
    }

    public async Task<Pessoa?> GetAsync(Guid id)
    {
        return await _repository.ObterAsync(id);
    }

    public async Task UpdateAsync(Pessoa pessoa)
    {
        await _repository.AtualizarAsync(pessoa);
    }
}