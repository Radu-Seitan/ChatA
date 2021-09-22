namespace ChatA.Application.Common.Events
{
    public class MessageCreatedEvent
    {
        public string Text { get; set; }
        public string SenderId { get; set; }
        public int RoomId { get; set; }
    }
}
