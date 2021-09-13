using ChatA.Application.Common.Exceptions;
using ChatA.Application.Common.Interfaces;
using ChatA.Domain.Entities;
using ChatA.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatA.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _appDbContext;
        public MessageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task CreateMessage(string senderId, int roomId, string text)
        {
            if(senderId is null)
            {
                throw new NotFoundException("User cannot be found");
            }
            if(string.IsNullOrWhiteSpace(text))
            {
                throw new BadRequestException("Message content cannot be empty");
            }
            var message = new Message()
            {
                SenderId = senderId,
                RoomId = roomId,
                Text = text
            };
            await _appDbContext.Messages.AddAsync(message);
            await _appDbContext.SaveChangesAsync();
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
