using ChatA.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.MessageRooms.Commands
{
    public class LeaveGroupMessageRoomCommand : IRequest<Unit>
    {
        public int RoomId { get; set; }
        public string UserId { get; set; }
    }

    public class LeaveGroupMessageRoomCommandHandler : IRequestHandler<LeaveGroupMessageRoomCommand, Unit>
    {
        private readonly IMessageRoomRepository _messageRoomRepository;
        public LeaveGroupMessageRoomCommandHandler(IMessageRoomRepository messageRoomRepository)
        {
            _messageRoomRepository = messageRoomRepository;
        }
        public async Task<Unit> Handle(LeaveGroupMessageRoomCommand request, CancellationToken cancellationToken)
        {
            var isOwner = await _messageRoomRepository.IsOwner(request.RoomId, request.UserId);
            await _messageRoomRepository.LeaveGroupMessageRoom(request.RoomId, request.UserId);
            if (isOwner)
            {
                await _messageRoomRepository.ReplaceOwner(request.RoomId);
            }
            return Unit.Value;
        }
    }

    public class LeaveGroupMessageRoomCommandValidator : AbstractValidator<LeaveGroupMessageRoomCommand>
    {
        public LeaveGroupMessageRoomCommandValidator()
        {
            RuleFor(m => m.RoomId).NotNull();
            RuleFor(m => m.UserId).NotNull();
        }
    }
}
