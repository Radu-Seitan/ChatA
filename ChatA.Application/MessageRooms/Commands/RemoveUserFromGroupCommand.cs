using ChatA.Application.Common.Exceptions;
using ChatA.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.MessageRooms.Commands
{
    public class RemoveUserFromGroupCommand : IRequest<Unit>
    {
        public int RoomId { get; set; }
        public string UserId { get; set; }
        public string OwnerId { get; set; }
    }
    public class RemoveUserFromGroupCommandHandler : IRequestHandler<RemoveUserFromGroupCommand, Unit>
    {
        private readonly IMessageRoomRepository _messageRoomRepository;
        public RemoveUserFromGroupCommandHandler(IMessageRoomRepository messageRoomRepository)
        {
            _messageRoomRepository = messageRoomRepository;
        }

        public async Task<Unit> Handle(RemoveUserFromGroupCommand request, CancellationToken cancellationToken)
        {
            var isOwner = await _messageRoomRepository.IsOwner(request.RoomId, request.OwnerId);
            if (!isOwner)
            {
                throw new BadRequestException();
            }
            await _messageRoomRepository.LeaveGroupMessageRoom(request.RoomId, request.UserId);
            return Unit.Value;
        }
    }
}
