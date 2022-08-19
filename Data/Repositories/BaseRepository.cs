using Bravi.Backend.Data.Context;
using Bravi.Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bravi.Backend.Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly BraviDbContext _context;

    public BaseRepository(BraviDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var instance = await _context.Set<TEntity>().FindAsync(id);

            if (instance == null) return;

            _context.Set<TEntity>().Remove(instance);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
    }


    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        try
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<TEntity?> FindAsync(Guid id)
    {
        try
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task UpdateAsync(TEntity entity, Guid id)
    {
        if (entity == null) return;

        var instance = await _context.Set<TEntity>().FindAsync(id);

        if (instance == null) return;

        _context.Entry(instance).CurrentValues.SetValues(entity);

        await _context.SaveChangesAsync();
    }
}