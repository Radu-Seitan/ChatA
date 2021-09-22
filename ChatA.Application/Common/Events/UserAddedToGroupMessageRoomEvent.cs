namespace ChatA.Application.Common.Events
{
    public class UserAddedToGroupMessageRoomEvent
    {
        public string OwnerId { get; set; }
        public int RoomId { get; set; }
        public string UserId { get; set; }
    }
}
