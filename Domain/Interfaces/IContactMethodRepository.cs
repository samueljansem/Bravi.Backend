using Bravi.Backend.Domain.Entities;

namespace Bravi.Backend.Domain.Interfaces;

public interface IContactMethodRepository
{
    Task<IEnumerable<ContactMethod>> ListAsync(Guid contactId);
    Task AddAsync(ContactMethod contactMethod);
    Task UpdateAsync(ContactMethod contactMethod);
    Task DeleteAsync(Guid id);
}