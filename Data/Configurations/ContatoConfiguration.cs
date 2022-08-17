using Bravi.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bravi.Backend.Data.Configurations;

public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.ToTable("Contatos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Tipo).IsRequired();

        builder.Property(x => x.Valor).IsRequired();

        builder.HasOne<Pessoa>(x => x.Pessoa).WithMany(x => x.Contatos).HasForeignKey(x => x.PessoaId);
    }
}
