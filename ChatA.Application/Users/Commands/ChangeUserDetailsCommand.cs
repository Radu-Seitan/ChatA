using ChatA.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.Users.Commands
{
    public class ChangeUserDetailsCommand : IRequest<Unit>
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }

    public class ChangeUserDetailsCommandHandler : IRequestHandler<ChangeUserDetailsCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserDetailsCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(ChangeUserDetailsCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.ChangeUserDetails(request.Id,request.Username,request.Email);
            return Unit.Value;
        }
    }
    public class ChangeUserDetailsCommandValidator : AbstractValidator<ChangeUserDetailsCommand>
    {
        public ChangeUserDetailsCommandValidator()
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
