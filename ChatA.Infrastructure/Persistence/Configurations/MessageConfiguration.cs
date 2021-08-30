using ChatA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatA.Infrastructure.Persistence.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasOne(m => m.Sender).WithMany().HasForeignKey(m => m.SenderId).IsRequired();
            builder.HasOne(m => m.Room).WithMany(m => m.Messages).HasForeignKey(m => m.RoomId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.Property(m => m.Text).HasMaxLength(200).IsRequired();
        }
    }
}
