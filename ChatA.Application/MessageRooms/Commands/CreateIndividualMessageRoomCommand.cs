using ChatA.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.MessageRooms.Commands
{
    public class CreateIndividualMessageRoomCommand : IRequest<Unit>
    {
        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
    }
    public class CreateIndividualMessageRoomCommandHandler : IRequestHandler<CreateIndividualMessageRoomCommand, Unit>
    {
        private readonly IMessageRoomRepository _messageRoomRepository;
        public CreateIndividualMessageRoomCommandHandler(IMessageRoomRepository messageRoomRepository)
        {
            _messageRoomRepository = messageRoomRepository;
        }
        public async Task<Unit> Handle(CreateIndividualMessageRoomCommand request, CancellationToken cancellationToken)
        {
            await _messageRoomRepository.CreateIndividualMessageRoom(request.FirstUserId, request.SecondUserId);
            return Unit.Value;
        }
    }
    public class CreateIndividualMessageRoomCommandValidator : AbstractValidator<CreateIndividualMessageRoomCommand>
    {
        public CreateIndividualMessageRoomCommandValidator()
        {
            RuleFor(m => m.FirstUserId).NotNull();
            RuleFor(m => m.SecondUserId).NotNull();
        }
    }
}
