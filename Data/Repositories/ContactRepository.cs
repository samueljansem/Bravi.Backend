using Bravi.Backend.Data.Context;
using Bravi.Backend.Domain.Entities;
using Bravi.Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bravi.Backend.Data.Repositories;

public class ContactRepository : BaseRepository<Contact>, IContactRepository
{
    private readonly BraviDbContext _context;

    public ContactRepository(BraviDbContext context) : base(context)
    {
        _context = context;
    }

    public new async Task AddAsync(Contact pessoa)
    {
        await base.AddAsync(pessoa);
    }

    public async Task UpdateAsync(Contact pessoa)
    {
        await base.UpdateAsync(pessoa, pessoa.Id);
    }

    public new async Task DeleteAsync(Guid id)
    {
        await base.DeleteAsync(id);
    }

    public async Task<Contact?> FindAsync(Guid id)
    {
        return await _context.Set<Contact>().Include(x => x.ContactMethods).Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Contact>> ListAsync()
    {
        return await _context.Set<Contact>().Include(x => x.ContactMethods).ToListAsync();
    }
}