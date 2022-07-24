using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id); //make up the primary key

            builder.Property(m => m.PhoneNumber).IsRequired(true).HasMaxLength(11);
            builder.Property(p => p.PasswordHash).IsRequired();
        }
    }
}
