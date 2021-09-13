using ChatA.Application.Common.Mappings;
using ChatA.Application.Messages.Queries;
using ChatA.Domain.Entities;
using ChatA.Domain.Enums;
using System.Collections.Generic;

namespace ChatA.Application.MessageRooms.Queries
{
    public class MessageRoomViewModel : IMapFrom<MessageRoom>
    {
        public string Name { get; set; }
        public List<MessageViewModel> Messages { get; set; }
        public RoomType Type { get; set; }
    }
}
