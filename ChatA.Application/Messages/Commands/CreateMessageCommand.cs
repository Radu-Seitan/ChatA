﻿using ChatA.Application.Common.Interfaces;
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
        private readonly INotifier<CreateMessageCommand> _notifier;
        public CreateMessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            await _messageRepository.CreateMessage(request.SenderId, request.RoomId, request.Text);
            await _notifier.Notify(request);
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
