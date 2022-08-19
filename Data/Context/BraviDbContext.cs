using Bravi.Backend.Data.Configurations;
using Bravi.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bravi.Backend.Data.Context;

public class BraviDbContext : DbContext
{
    public BraviDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Contact> Pessoas { get; set; }
    public DbSet<ContactMethod> Contatos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Contact>(new ContactConfiguration().Configure);
        builder.Entity<ContactMethod>(new ContactMethodConfiguration().Configure);

        base.OnModelCreating(builder);
    }
}