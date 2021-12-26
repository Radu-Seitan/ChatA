using ChatA.Application.Common.Exceptions;
using ChatA.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.MessageRooms.Commands
{
    public class DeleteMessageRoomCommand : IRequest<Unit>
    {
        public int RoomId { get; set; }
        public string UserId { get; set; }
    }

    public class DeleteMessageRoomCommandHandler : IRequestHandler<DeleteMessageRoomCommand, Unit>
    {
        private readonly IMessageRoomRepository _messageRoomRepository;
        public DeleteMessageRoomCommandHandler(IMessageRoomRepository messageRoomRepository)
        {
            _messageRoomRepository = messageRoomRepository;
        }
        public async Task<Unit> Handle(DeleteMessageRoomCommand request, CancellationToken cancellationToken)
        {
            var isOwner = await _messageRoomRepository.IsOwner(request.RoomId, request.UserId);
            if (!isOwner)
            {
                throw new BadRequestException();
            }

            await _messageRoomRepository.DeleteMessageRoom(request.RoomId);
            return Unit.Value;
        }
    }

    public class DeleteMessageRoomCommandValidator : AbstractValidator<DeleteMessageRoomCommand>
    {
        public DeleteMessageRoomCommandValidator()
        {
            RuleFor(m => m.RoomId).NotNull();
            RuleFor(m => m.UserId).NotNull();
        }
    }

}
