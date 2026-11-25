using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");

            builder.HasKey(ur => ur.Id);

            builder.HasOne(ur => ur.User)
                   .WithMany(ur => ur.UserRoles)
                   .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Role)
                   .WithMany(ur => ur.UserRoles)
                   .HasForeignKey(ur => ur.RoleId);

        }
    }
}
