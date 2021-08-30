using ChatA.Domain.Enums;

namespace ChatA.Domain.Entities
{
    public class Membership 
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int RoomId { get; set; }
        public MessageRoom Room { get; set; }
        public MembershipRole Role { get; set; }
    }
}
