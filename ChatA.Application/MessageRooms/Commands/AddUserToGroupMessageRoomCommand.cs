using ChatA.Application.Common.Events;
using ChatA.Application.Common.Exceptions;
using ChatA.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.MessageRooms.Commands
{
    public class AddUserToGroupMessageRoomCommand : IRequest<Unit>
    {
        public string OwnerId { get; set; }
        public int RoomId { get; set; }
        public string UserId { get; set; }
    }

    public class AddUserToGroupMessageRoomCommandHandler : IRequestHandler<AddUserToGroupMessageRoomCommand,Unit>
    {
        private readonly IMessageRoomRepository _messageRoomRepository;
        private readonly INotifier<UserAddedToGroupMessageRoomEvent> _notifier;
        public AddUserToGroupMessageRoomCommandHandler(IMessageRoomRepository messageRoomRepository, INotifier<UserAddedToGroupMessageRoomEvent> notifier)
        {
            _messageRoomRepository = messageRoomRepository;
            _notifier = notifier;
        }

        public async Task<Unit> Handle(AddUserToGroupMessageRoomCommand request, CancellationToken cancellationToken)
        {
            var isOwner = await _messageRoomRepository.IsOwner(request.RoomId,request.UserId);
            if(!isOwner)
            {
                throw new BadRequestException();
            }
            await _messageRoomRepository.AddUserToGroupMessageRoom(request.RoomId, request.UserId, request.OwnerId);
            var @event = new UserAddedToGroupMessageRoomEvent
            {
                OwnerId = request.OwnerId,
                RoomId = request.RoomId,
                UserId = request.UserId
            };
            await _notifier.Notify(@event);
            return Unit.Value;
        }
    }

    public class AddUserToGroupMessageRoomCommandValidator : AbstractValidator<AddUserToGroupMessageRoomCommand>
    {
        public AddUserToGroupMessageRoomCommandValidator()
        {
            RuleFor(m => m.UserId).NotNull();
        }
    }
}
