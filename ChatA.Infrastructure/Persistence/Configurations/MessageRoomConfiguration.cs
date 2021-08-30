using ChatA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ChatA.Infrastructure.Persistence.Configurations
{
    public class MessageRoomConfiguration : IEntityTypeConfiguration<MessageRoom>
    {
        public void Configure(EntityTypeBuilder<MessageRoom> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
        }
    }
}
