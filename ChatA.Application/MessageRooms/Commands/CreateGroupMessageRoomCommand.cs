using ChatA.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.MessageRooms.Commands
{
    public class CreateGroupMessageRoomCommand : IRequest<Unit>
    {
        public string OwnerId { get; set; }
        public string Name { get; set; }
    }

    public class CreateGroupMessageRoomCommandHandler : IRequestHandler<CreateGroupMessageRoomCommand,Unit>
    {
        private readonly IMessageRoomRepository _messageRoomRepository;
        public CreateGroupMessageRoomCommandHandler(IMessageRoomRepository messageRoomRepository)
        {
            _messageRoomRepository = messageRoomRepository;
        }

        public async Task<Unit> Handle(CreateGroupMessageRoomCommand request, CancellationToken cancellationToken)
        {
            await _messageRoomRepository.CreateGroupMessageRoom(request.OwnerId, request.Name);
            return Unit.Value;
        }
    }

    public class CreateGroupMessageRoomCommandValidator : AbstractValidator<CreateGroupMessageRoomCommand>
    {
        public CreateGroupMessageRoomCommandValidator()
        {
            RuleFor(m => m.OwnerId).NotNull();
            RuleFor(m => m.Name).NotNull().MaximumLength(50);
        }
    }
}
