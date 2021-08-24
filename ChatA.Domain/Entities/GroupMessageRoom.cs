using System.Collections.Generic;

namespace ChatA.Domain.Entities
{
    public class GroupMessageRoom : Message
    {
        public List<GroupMembership> Memberships { get; set; }
    }
}
