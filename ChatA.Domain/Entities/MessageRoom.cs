using ChatA.Domain.Common;
using System.Collections.Generic;

namespace ChatA.Domain.Entities
{
    public abstract class MessageRoom : BaseEntity
    {
        public List<Message> Messages { get; set; }
    }
}
