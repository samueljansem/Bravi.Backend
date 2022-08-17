using Bravi.Backend.Domain.Entities;
using Bravi.Backend.Domain.Interfaces;

namespace Bravi.Backend.Application.Services;

public class ContatoService : IContatoService
{
    private readonly IContatoRepository _repository;

    public ContatoService(IContatoRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(Contato contato)
    {
        await _repository.AdicionarAsync(contato);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeletarAsync(id);
    }

    public async Task<IEnumerable<Contato>> GetAllAsync(Guid personId)
    {
        return await _repository.ObterTodosAsync(personId);
    }

    public async Task<Contato?> GetAsync(Guid id)
    {
        return await _repository.ObterAsync(id);
    }

    public async Task UpdateAsync(Contato contato)
    {
        await _repository.AtualizarAsync(contato);
    }
}