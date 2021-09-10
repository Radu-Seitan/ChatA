using ChatA.Domain.Common;
using ChatA.Domain.Enums;
using System.Collections.Generic;

namespace ChatA.Domain.Entities
{
    public class MessageRoom : BaseEntity
    {
        public string Name { get; set; }
        public List<Message> Messages { get; set; }
        public RoomType Type { get; set; }
        public List<Membership> Memberships { get; set; }
    }
}
