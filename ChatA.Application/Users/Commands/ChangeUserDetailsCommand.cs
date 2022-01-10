using ChatA.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.Users.Commands
{
    public class ChangeUserDetailsCommand : IRequest<Unit>
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Guid? ImageId { get; set; }
    }

    public class ChangeUserDetailsCommandHandler : IRequestHandler<ChangeUserDetailsCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAppImageRepository _appImageRepository;

        public ChangeUserDetailsCommandHandler(IUserRepository userRepository, IAppImageRepository appImageRepository)
        {
            _userRepository = userRepository;
            _appImageRepository = appImageRepository;
        }
        public async Task<Unit> Handle(ChangeUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.UserId);
            if(user.ImageId is not null && request.ImageId is not null)
            {
                await _appImageRepository.DeleteImage(user.ImageId.Value);
            }

            await _userRepository.ChangeUserDetails(request.UserId, request.Username, request.Email, request.ImageId);

            return Unit.Value;
        }
    }

    public class ChangeUserDetailsCommandValidator : AbstractValidator<ChangeUserDetailsCommand>
    {
        public ChangeUserDetailsCommandValidator()
        {
            RuleFor(v => v.UserId)
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
