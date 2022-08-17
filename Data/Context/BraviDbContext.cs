using Bravi.Backend.Data.Configurations;
using Bravi.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bravi.Backend.Data.Context;

public class BraviDbContext : DbContext
{
    public BraviDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Contato> Contatos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Pessoa>(new PessoaConfiguration().Configure);
        builder.Entity<Contato>(new ContatoConfiguration().Configure);

        base.OnModelCreating(builder);
    }
}