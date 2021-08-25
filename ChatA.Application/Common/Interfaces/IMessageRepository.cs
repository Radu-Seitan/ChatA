using ChatA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface IMessageRepository
    {
        Task CreateMessage(Message message);
        Task<IEnumerable<Message>> GetMessages(int messageRoomId);
    }
}
