using Bravi.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bravi.Backend.Data.Configurations;

public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome).IsRequired();

        builder.Property(x => x.Nascimento).IsRequired();

    }
}
