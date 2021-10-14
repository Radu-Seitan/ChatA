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
        public AddUserToGroupMessageRoomCommandHandler(IMessageRoomRepository messageRoomRepository)
        {
            _messageRoomRepository = messageRoomRepository;
        }

        public async Task<Unit> Handle(AddUserToGroupMessageRoomCommand request, CancellationToken cancellationToken)
        {
            var isOwner = await _messageRoomRepository.IsOwner(request.RoomId,request.OwnerId);
            if(!isOwner)
            {
                throw new BadRequestException();
            }
            await _messageRoomRepository.AddUserToGroupMessageRoom(request.RoomId, request.UserId, request.OwnerId);
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
