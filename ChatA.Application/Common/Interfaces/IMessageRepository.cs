using ChatA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessage(string senderId, int roomId, string text);
        Task<IEnumerable<Message>> GetMessages(int messageRoomId);
    }
}
