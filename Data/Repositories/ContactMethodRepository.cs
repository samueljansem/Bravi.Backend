using Bravi.Backend.Data.Context;
using Bravi.Backend.Domain.Entities;
using Bravi.Backend.Domain.Interfaces;

namespace Bravi.Backend.Data.Repositories;

public class ContactMethodRepository : BaseRepository<ContactMethod>, IContactMethodRepository
{
    public ContactMethodRepository(BraviDbContext context) : base(context) { }

    public new async Task AddAsync(ContactMethod contactMethod)
    {
        await base.AddAsync(contactMethod);
    }

    public async Task UpdateAsync(ContactMethod contactMethod)
    {
        await base.UpdateAsync(contactMethod, contactMethod.Id);
    }

    public new async Task DeleteAsync(Guid id)
    {
        await base.DeleteAsync(id);
    }

    public new async Task<ContactMethod?> FindAsync(Guid id)
    {
        return await base.FindAsync(id);
    }

    public async Task<IEnumerable<ContactMethod>> ListAsync(Guid contactId)
    {
        var contacts = await base.ListAsync();
        return contacts.Where(x => x.ContactId == contactId);
    }
}