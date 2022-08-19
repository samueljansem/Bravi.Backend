using Bravi.Backend.Domain.Entities;

namespace Bravi.Backend.Domain.Interfaces;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> ListAsync();
    Task<Contact?> FindAsync(Guid id);
    Task AddAsync(Contact contact);
    Task UpdateAsync(Contact contact);
    Task DeleteAsync(Guid id);
}