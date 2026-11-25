using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.RoleName).IsRequired().HasMaxLength(50);
            builder.HasIndex(r => r.RoleName).IsUnique();

            builder.HasData(SeedData.Roles());
        }
    }
}
