using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.EntityConfiguration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();


            builder.HasOne(r => r.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
