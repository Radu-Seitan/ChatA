using ChatA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatA.Domain.Entities
{
    class Message : BaseEntity
    {
        public string Content { get; set; }
        public string SenderId { get; set; }
        public int RoomId { get; set; }
    }
}
