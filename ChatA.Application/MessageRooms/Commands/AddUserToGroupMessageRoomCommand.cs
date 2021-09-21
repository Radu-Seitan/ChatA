using ChatA.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.MessageRooms.Commands
{
    public class AddUserToGroupMessageRoomCommand : IRequest<Unit>
    {
        public int RoomId { get; set; }
        public string UserId { get; set; }
    }

    public class AddUserToGroupMessageRoomCommandHandler : IRequestHandler<AddUserToGroupMessageRoomCommand,Unit>
    {
        private readonly IMessageRoomRepository _messageRoomRepository;
        private readonly INotifier<AddUserToGroupMessageRoomCommand> _notifier;
        public AddUserToGroupMessageRoomCommandHandler(IMessageRoomRepository messageRoomRepository)
        {
            _messageRoomRepository = messageRoomRepository;
        }

        public async Task<Unit> Handle(AddUserToGroupMessageRoomCommand request, CancellationToken cancellationToken)
        {
            await _messageRoomRepository.AddUserToGroupMessageRoom(request.RoomId, request.UserId);
            await _notifier.Notify(request);
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
