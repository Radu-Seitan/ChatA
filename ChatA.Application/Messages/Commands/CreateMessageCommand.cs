using AutoMapper;
using ChatA.Application.Common.Events;
using ChatA.Application.Common.Interfaces;
using ChatA.Application.Messages.Queries;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.Messages.Commands
{
    public class CreateMessageCommand : IRequest<Unit>
    {
        public string Text { get; set; }
        public string SenderId { get; set; }
        public int RoomId { get; set; }
    }

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Unit>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly INotifier<MessageViewModel> _notifier;
        private readonly IMapper _mapper;

        public CreateMessageCommandHandler(IMessageRepository messageRepository, INotifier<MessageViewModel> notifier, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _notifier = notifier;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.CreateMessage(request.SenderId, request.RoomId, request.Text);
            var @event = _mapper.Map<MessageViewModel>(message); 
            await _notifier.Notify(@event);
            return Unit.Value;
        }
    }
    public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageCommandValidator()
        {
            RuleFor(v => v.Text)
                .NotNull()
                .MaximumLength(200);
            RuleFor(v => v.SenderId)
                .NotNull();
            RuleFor(v => v.RoomId)
                .NotNull();
        }
    }
    
}
