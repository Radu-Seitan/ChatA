﻿using ChatA.Application.Common.Exceptions;
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
        public async Task AddUserToGroupMessageRoom(int roomId, string userId)
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

            var searhedForExistingRoom = await _appDbContext.MessageRooms.
                Where(m => m.Name.Equals($"{firstUser.Username} & {secondUser.Username}") && m.Type == RoomType.Individual)
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

        public async Task CreateMessage(Message message)
        {
            await _appDbContext.Messages.AddAsync(message);
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

        public async Task<IEnumerable<Message>> GetMessages(int messageRoomId)
        {
            var room = await _appDbContext.MessageRooms.FindAsync(messageRoomId);
            if (room is null)
            {
                throw new NotFoundException("Room cannot be found");
            }

            return room.Messages;
        }
    }
}
