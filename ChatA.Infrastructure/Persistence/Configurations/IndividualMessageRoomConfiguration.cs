using ChatA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatA.Infrastructure.Persistence.Configurations
{
    public class IndividualMessageRoomConfiguration : IEntityTypeConfiguration<IndividualMessageRoom>
    {
        public void Configure(EntityTypeBuilder<IndividualMessageRoom> builder)
        {
            builder.HasOne(t => t.FirstUser)
                .WithMany(t => t.FirstIndividualMessageRooms)
                .HasForeignKey(t => t.FirstUserId);
            builder.HasOne(t => t.SecondUser)
                .WithMany(t => t.SecondIndividualMessageRooms)
                .HasForeignKey(t => t.SecondUserId);
        }
    }
}
