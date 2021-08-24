namespace ChatA.Domain.Entities
{
    public class IndividualMessageRoom : MessageRoom
    {
        public string FirstUserId { get; set; }
        public User FirstUser { get; set; }
        public string SecondUserID { get; set; }
        public User SecondUser { get; set; }
    }
}
