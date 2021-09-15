using ChatA.Application.Common.Interfaces;
using ChatA.Domain.Entities;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = request.Id,
                Username = request.Username,
                Email = request.Email,
                Memberships = new()
            };

            await _userRepository.CreateUser(user);
            return Unit.Value;
        }
    }
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotNull();
            RuleFor(v => v.Username)
                .MaximumLength(40)
                .NotNull();
            RuleFor(v => v.Email)
                .MaximumLength(40)
                .NotNull();
        }
    }
}
