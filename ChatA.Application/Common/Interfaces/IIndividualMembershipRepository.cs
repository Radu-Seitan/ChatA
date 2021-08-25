using ChatA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface IIndividualMembershipRepository
    {
        void CreateIndividualMembership(User firstUser, User secondUser);
        IEnumerable<IndividualMembership> GetIndividualMemberships(User user);
    }
}
