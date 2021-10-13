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
    public class GetUsersInRoomQuery : IRequest<IEnumerable<UserViewModel>>
    {
        public int RoomId { get; set; }
    }

    public class GetUsersInRoomQueryHandler : IRequestHandler<GetUsersInRoomQuery, IEnumerable<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUsersInRoomQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserViewModel>> Handle(GetUsersInRoomQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersInRoom(request.RoomId);
            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }
    }

    public class GetUsersInRoomQueryValidator : AbstractValidator<SearchAllUsersQuery>
    {
        public GetUsersInRoomQueryValidator()
        {
            RuleFor(q => q.SearchedUsername)
                .NotNull();
        }
    }
}
