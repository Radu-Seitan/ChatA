using ChatA.Domain.Common;
using ChatA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatA.Domain.Entities
{
    class Membership : BaseEntity
    {
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public MembershipRoles Role { get; set; }
    }
}
