using Bravi.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bravi.Backend.Data.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FullName).IsRequired();

        builder.Property(x => x.BirthDate).IsRequired();

        builder.Property(x => x.IsFavorite).IsRequired().HasDefaultValue(false);
    }
}
