using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetStore.Models;

namespace PetStore.Data.Profiles
{
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.Username)
                .IsUnicode(false);

            builder.Property(c => c.Email)
                .IsUnicode(false);
        }
    }
}
