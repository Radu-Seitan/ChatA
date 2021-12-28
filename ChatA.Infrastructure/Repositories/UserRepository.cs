using ChatA.Application.Common.Exceptions;
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
            return await _appDbContext.Users.Include(u => u.Memberships).Where(u => u.Memberships.Where(m => m.Room == room).Count() == 1).ToListAsync();
        }

        public async Task ChangeUserDetails(string userId, string username, string email)
        {
            var user = await _appDbContext.Users.FindAsync(userId);
            if (user is null)
            {
                throw new NotFoundException("User cannot be found");
            }
            var oldUsername = user.Username;
            user.Email = email;
            user.Username = username;
            var rooms = _appDbContext.MessageRooms.Where(mr => mr.Name.Contains(oldUsername)).ToList();
            foreach(var room in rooms)
            {
                room.Name = room.Name.Replace(oldUsername, username);
            }
            await _appDbContext.SaveChangesAsync();
        }
    }
}
