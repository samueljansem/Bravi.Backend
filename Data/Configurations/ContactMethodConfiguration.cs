using Bravi.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bravi.Backend.Data.Configurations;

public class ContactMethodConfiguration : IEntityTypeConfiguration<ContactMethod>
{
    public void Configure(EntityTypeBuilder<ContactMethod> builder)
    {
        builder.ToTable("ContactMethods");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Key).IsRequired();

        builder.Property(x => x.Value).IsRequired();

        builder.HasOne<Contact>(x => x.Contact).WithMany(x => x.ContactMethods).HasForeignKey(x => x.ContactId);
    }
}
