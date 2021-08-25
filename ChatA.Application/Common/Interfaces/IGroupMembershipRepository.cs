using ChatA.Domain.Entities;
using ChatA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface IGroupMembershipRepository
    {
        Task AddUserToGroupMessageRoom(int roomId, string userId, MembershipRole role);
    }
}
