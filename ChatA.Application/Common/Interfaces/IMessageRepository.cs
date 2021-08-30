using ChatA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface IMessageRepository
    {
        Task CreateMessage(Message message);
        Task<IEnumerable<Message>> GetMessages(int messageRoomId);
    }
}
