using System.Collections.Generic;

namespace ChatA.Domain.Entities
{
    public class GroupMessageRoom : Message
    {
        public List<Membership> Memberships { get; set; }
    }
}
