using System.Collections.Generic;

namespace ChatA.Domain.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<GroupMembership> GroupMemberships { get; set; }
        public List<IndividualMessageRoom> IndividualMessageRooms { get; set; } 
    }
}
