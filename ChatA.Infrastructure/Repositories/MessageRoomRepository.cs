using ChatA.Application.Common.Exceptions;
using ChatA.Application.Common.Interfaces;
using ChatA.Domain.Entities;
using ChatA.Domain.Enums;
using ChatA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatA.Infrastructure.Repositories
{
    public class MessageRoomRepository : IMessageRoomRepository
    {
        private readonly AppDbContext _appDbContext;
        public MessageRoomRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddUserToGroupMessageRoom(int roomId, string userId, string ownerId)
        {
            var roomToBeAdded = await _appDbContext.MessageRooms.FindAsync(roomId);
            if(roomToBeAdded is null)
            {
                throw new NotFoundException("Room cannot be found");
            }

            var userToBeAdded = await _appDbContext.Users.FindAsync(userId);
            if (userToBeAdded is null)
            {
                throw new NotFoundException("User cannot be found");
            }

            Membership membership = new()
            {
                Room = roomToBeAdded,
                RoomId = roomId,
                User = userToBeAdded,
                UserId = userId,
                Role = MembershipRole.Default
            };

            await _appDbContext.Memberships.AddAsync(membership);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<bool> IsOwner(int roomId, string userId)
        {
            var membership =  await _appDbContext.Memberships
                .Include(m => m.User)
                .ThenInclude(m => m.Memberships)
                .FirstOrDefaultAsync(m => m.UserId == userId && m.RoomId == roomId);
            return membership.Role == MembershipRole.Owner;
        }

        public async Task CreateGroupMessageRoom(string ownerId, string name)
        {
            var owner = await _appDbContext.Users.FindAsync(ownerId);
            if (owner is null)
            {
                throw new NotFoundException("User cannot be found");
            }

            MessageRoom messageRoom = new()
            {
                Name = name,
                Messages = new List<Message>(),
                Type = RoomType.Group
            };

            await _appDbContext.MessageRooms.AddAsync(messageRoom);

            Membership membership = new()
            {
                Room = messageRoom,
                RoomId = messageRoom.Id,
                User = owner,
                UserId = ownerId,
                Role = MembershipRole.Owner
            };

            await _appDbContext.Memberships.AddAsync(membership);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task CreateIndividualMessageRoom(string firstUserId, string secondUserId)
        {
            var firstUser = await _appDbContext.Users.FindAsync(firstUserId);
            if (firstUser is null)
            {
                throw new NotFoundException("User cannot be found");
            }

            var secondUser = await _appDbContext.Users.FindAsync(secondUserId);
            if (secondUser is null)
            {
                throw new NotFoundException("User cannot be found");
            }

            var userIds = new List<string> { firstUserId, secondUserId };
            var searhedForExistingRoom = await _appDbContext.MessageRooms
                .Include(m => m.Memberships)
                .Where(m => m.Type == RoomType.Individual && m.Memberships.Select(mx => mx.UserId).All(id => userIds.Contains(id)))
                .ToListAsync();

            if(searhedForExistingRoom.Count() != 0)
            {
                throw new BadRequestException("A message room already exists with the two users");
            }

            MessageRoom messageRoom = new()
            {
                Name = $"{firstUser.Username} & {secondUser.Username}",
                Messages = new List<Message>(),
                Type = RoomType.Individual
            };

            await _appDbContext.MessageRooms.AddAsync(messageRoom);

            Membership firstMembership = new()
            {
                Room = messageRoom,
                RoomId = messageRoom.Id,
                User = firstUser,
                UserId = firstUser.Id,
                Role = MembershipRole.Default
            };

            await _appDbContext.Memberships.AddAsync(firstMembership);

            Membership secondMembership = new()
            {
                Room = messageRoom,
                RoomId = messageRoom.Id,
                User = secondUser,
                UserId = secondUser.Id,
                Role = MembershipRole.Default
            };

            await _appDbContext.Memberships.AddAsync(secondMembership);
            await _appDbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<MessageRoom>> GetMessageRooms(string userId)
        {
            var user = await _appDbContext.Users.FindAsync(userId);
            if (user is null)
            {
                throw new NotFoundException("User cannot be found");
            }

            return  await _appDbContext.Memberships.Where(m => m.User.Equals(user)).Select(m => m.Room).ToListAsync();
        }

        public async Task DeleteMessageRoom(int roomId)
        {
            var room = await _appDbContext.MessageRooms.FindAsync(roomId);
            if (room is null)
            {
                throw new NotFoundException("Room cannot be found");
            }

            _appDbContext.MessageRooms.Remove(room);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task LeaveGroupMessageRoom(int roomId, string userId)
        {
            var room = await _appDbContext.MessageRooms.FindAsync(roomId);
            if (room is null)
            {
                throw new NotFoundException("Room cannot be found");
            }
            var user = await _appDbContext.MessageRooms.FindAsync(userId);
            if (user is null)
            {
                throw new NotFoundException("User cannot be found");
            }

            var membership = await _appDbContext.Memberships.FindAsync(user.Id, room.Id);
            _appDbContext.Memberships.Remove(membership);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task ReplaceOwner(int roomId)
        {
            var newOwnerMembership = await _appDbContext.Memberships.FirstOrDefaultAsync(m => m.RoomId == roomId);
            if (newOwnerMembership is null)
            {
                return;
            }
            newOwnerMembership.Role = MembershipRole.Owner;
            await _appDbContext.SaveChangesAsync();
        }

    }
}
