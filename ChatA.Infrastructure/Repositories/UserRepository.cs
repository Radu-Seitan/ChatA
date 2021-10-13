using ChatA.Application.Common.Interfaces;
using ChatA.Domain.Entities;
using ChatA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatA.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task CreateUser(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUser(string userId)
        {
            return await _appDbContext.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> SearchUsers(string searchUsername = "")
        {
            return await _appDbContext.Users.Where(u => u.Username.Contains(searchUsername)).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersInRoom(int roomId)
        {
            var room = await _appDbContext.MessageRooms.FindAsync(roomId);
            return await _appDbContext.Users.Where(u => u.Memberships.Where(m => m.Room == room).ToList().Count() == 1).ToListAsync();
        }
    }
}
