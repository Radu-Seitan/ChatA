namespace ChatA.Domain.Entities
{
    public class IndividualMessageRoom : MessageRoom
    {
        public int MembershipId { get; set; }
        public IndividualMembership Membership { get; set; }
    }
}
