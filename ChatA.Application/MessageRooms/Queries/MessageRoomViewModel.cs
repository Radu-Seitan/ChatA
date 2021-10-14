using AutoMapper;
using ChatA.Application.Common.Mappings;
using ChatA.Application.Messages.Queries;
using ChatA.Domain.Entities;
using ChatA.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ChatA.Application.MessageRooms.Queries
{
    public class MessageRoomViewModel : IMapFrom<MessageRoom>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MessageViewModel> Messages { get; set; }
        public RoomType Type { get; set; }
        public string OwnerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MessageRoom, MessageRoomViewModel>()
                .ForMember(d => d.OwnerId, opt => opt.MapFrom(m => m.Memberships.FirstOrDefault(e => e.Role == MembershipRole.Owner).UserId));
        }
    }
}
