using ChatA.Domain.Common;

namespace ChatA.Domain.Entities
{
    public class IndividualMembership : BaseEntity
    {
        public string FirstUserId { get; set; }
        public User FirstUser { get; set; }
        public string SecondUserId { get; set; }
        public User SecondUser { get; set; }
    }
}
