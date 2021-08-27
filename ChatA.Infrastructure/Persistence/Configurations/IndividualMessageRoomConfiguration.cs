using ChatA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
