namespace ChatA.Domain.Entities
{
    public class IndividualMessageRoom : MessageRoom
    {
        public string FirstUserId { get; set; }
        public User FirstUser { get; set; }
        public string SecondUserId { get; set; }
        public User SecondUser { get; set; }
    }
}
