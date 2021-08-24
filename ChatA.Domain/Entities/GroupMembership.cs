using ChatA.Domain.Enums;

namespace ChatA.Domain.Entities
{
    public class GroupMembership 
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int RoomId { get; set; }
        public MessageRoom MessageRoom { get; set; }
        public MembershipRoles Role { get; set; }
    }
}
