namespace ChatA.Domain.Entities
{
    public class IndividualMessageRoom : MessageRoom
    {
        public User FirstUser { get; set; }
        public User SecondUser { get; set; }
    }
}
