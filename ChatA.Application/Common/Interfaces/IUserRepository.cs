using ChatA.Domain.Entities;
using System.Collections.Generic;

namespace ChatA.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        User GetUser(string userId);
    }
}
