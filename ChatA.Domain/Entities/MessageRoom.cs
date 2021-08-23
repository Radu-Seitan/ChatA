using ChatA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatA.Domain.Entities
{
    abstract class MessageRoom : BaseEntity
    {
        public List<Message> Messages { get; set; }
    }
}
