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

        public async Task<IEnumerable<User>> SearchUsers(string searchUsername)
        {
            return await _appDbContext.Users.Where(u => u.Username.Contains(searchUsername)).ToListAsync();
        }
    }
}
