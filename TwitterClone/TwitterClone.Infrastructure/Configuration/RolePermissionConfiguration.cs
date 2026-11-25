using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Configuration
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissoin>
    {
        public void Configure(EntityTypeBuilder<RolePermissoin> builder)
        {
            builder.ToTable("RolePermissions");

            builder.HasKey(rp => rp.Id);

            builder.HasOne(rp => rp.Role)
                   .WithMany(rp => rp.RolePermissoins)
                   .HasForeignKey(rp => rp.RoleId);

            builder.HasOne(rp => rp.Permission)
                   .WithMany(rp => rp.RolePermissoins)
                   .HasForeignKey(rp => rp.PermissionId);

            builder.HasData(SeedData.RolePermissoins());
        }
    }
}
