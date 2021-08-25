using System.Collections.Generic;

namespace ChatA.Domain.Entities
{
    public class GroupMessageRoom : MessageRoom
    {
        public List<GroupMembership> Memberships { get; set; }
        public string Name { get; set; }
    }
}
