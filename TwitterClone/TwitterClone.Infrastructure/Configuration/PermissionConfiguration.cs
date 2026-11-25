using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasIndex(p => p.Id);

            builder.Property(r => r.PermissionName).IsRequired().HasMaxLength(50);
            builder.HasIndex(r => r.PermissionName).IsUnique();

            builder.HasData(SeedData.Permissions());
        }
    }
}
