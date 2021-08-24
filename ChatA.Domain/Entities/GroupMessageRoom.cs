using System.Collections.Generic;

namespace ChatA.Domain.Entities
{
    public class GroupMessageRoom : Message
    {
        public List<User> UserList { get; set; }
    }
}
