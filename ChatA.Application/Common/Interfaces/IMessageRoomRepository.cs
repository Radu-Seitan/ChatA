﻿using ChatA.Domain.Entities;
using ChatA.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface IMessageRoomRepository
    {
        Task CreateIndividualMessageRoom(string firstUserId, string secondUserId);
        Task CreateGroupMessageRoom(string ownerId, string name);
        Task<IEnumerable<MessageRoom>> GetMessageRooms(string userId);
        Task CreateMessage(Message message);
        Task<IEnumerable<Message>> GetMessages(int messageRoomId);
        Task AddUserToGroupMessageRoom(int roomId, string userId);
    }
}
