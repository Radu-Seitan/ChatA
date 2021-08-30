﻿using ChatA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface IMessageRoomRepository
    {
        Task CreateIndividualMessageRoom(string firstUserId, string secondUserId);
        Task CreateGroupMessageRoom(string ownerId, string name);
        Task<IEnumerable<MessageRoom>> GetMessageRooms(string userId);
    }
}