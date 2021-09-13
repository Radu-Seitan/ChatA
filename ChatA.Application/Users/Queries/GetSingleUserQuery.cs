using AutoMapper;
using ChatA.Application.Common.Interfaces;
using ChatA.Domain.Entities;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.Users.Queries
{
    public class GetSingleUserQuery : IRequest<UserViewModel>
    {
        public string Id { get; set; }
    }

    public class GetSingleUserQueryHandler : IRequestHandler<GetSingleUserQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetSingleUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserViewModel> Handle(GetSingleUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.Id);
            return _mapper.Map<User, UserViewModel>(user);
        }
    }

    public class GetSingleUserQueryValidator : AbstractValidator<GetSingleUserQuery>
    {
        public GetSingleUserQueryValidator()
        {
            RuleFor(q => q.Id)
                .NotNull();
        }
    }
}
