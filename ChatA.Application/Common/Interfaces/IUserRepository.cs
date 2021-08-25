using ChatA.Domain.Entities;
using System.Collections.Generic;

namespace ChatA.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        IEnumerable<MessageRoom> GetMessageRooms(User user);
        IEnumerable<IndividualMembership> GetIndividualMemberships(User user);
        IEnumerable<GroupMembership> GetGroupMemberships(User user);
        User GetUser(string userId);
    }
}
