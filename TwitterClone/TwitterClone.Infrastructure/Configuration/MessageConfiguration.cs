
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Configuration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SenderId)
                .IsRequired();

            builder.Property(x => x.ReceiverId)
                .IsRequired();

            builder.Property(x => x.SentAt)
                .IsRequired();

            builder.Property(x => x.IsRead)
                .HasDefaultValue(false);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.OwnsOne(x => x.Content, content =>
            {
                content.Property(x => x.Text)
                    .HasColumnName("ContentText")
                    .IsRequired();

                content.Property(x => x.ImageUrl)
                    .HasColumnName("ContentImageUrl");
            });

            builder.Navigation(x => x.Content)
                .IsRequired();
        }
    }
}
