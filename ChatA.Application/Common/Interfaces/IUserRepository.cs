using ChatA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<IEnumerable<User>> SearchUsers(string searchUsername);
    }
}
