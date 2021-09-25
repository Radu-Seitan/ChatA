using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChatA.Application.Common.Interfaces;
using ChatA.Domain.Entities;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.Users.Queries
{
    public class SearchAllUsersQuery : IRequest<IEnumerable<UserViewModel>>
    {
        public string SearchedUsername { get; set; } = "";
    }

    public class SearchAllUsersQueryHandler : IRequestHandler<SearchAllUsersQuery, IEnumerable<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public SearchAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserViewModel>> Handle(SearchAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.SearchUsers(request.SearchedUsername);
            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }
    }

    public class SearchAllUsersQueryValidator : AbstractValidator<SearchAllUsersQuery>
    {
        public SearchAllUsersQueryValidator()
        {
            RuleFor(q => q.SearchedUsername)
                .NotNull();
        }
    }
}
