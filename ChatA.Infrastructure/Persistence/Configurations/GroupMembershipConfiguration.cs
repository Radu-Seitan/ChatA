using ChatA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatA.Infrastructure.Persistence.Configurations
{
    public class GroupMembershipConfiguration : IEntityTypeConfiguration<GroupMembership>
    {
        public void Configure(EntityTypeBuilder<GroupMembership> builder)
        {
            builder.HasKey(g => new
            {
                g.UserId,
                g.RoomId
            });
            builder.Property(g => g.Role).IsRequired();
        }
    }
}
