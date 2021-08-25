﻿using ChatA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface IGroupMembershipRepository
    {
        void CreateGroupMembership(User firstUser, User secondUser);
        IEnumerable<GroupMembership> GetGroupMemberships(User user);
    }
}
