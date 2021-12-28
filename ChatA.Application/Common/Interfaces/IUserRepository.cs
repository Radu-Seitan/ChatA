using ChatA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<IEnumerable<User>> SearchUsers(string searchUsername);
        Task<User> GetUser(string userId);

        Task<IEnumerable<User>> GetUsersInRoom(int roomId);
        Task ChangeUserDetails(string userId, string username, string email);
    }
}
