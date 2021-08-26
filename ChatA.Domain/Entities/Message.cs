using ChatA.Domain.Common;

namespace ChatA.Domain.Entities
{
    public class Message : BaseEntity
    {
        public string Content { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public int RoomId { get; set; }
        public MessageRoom Room { get; set; }
    }
}
