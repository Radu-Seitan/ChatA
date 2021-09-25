using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChatA.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.MessageRooms.Queries
{
    public class GetMessageRoomsQuery : IRequest<IEnumerable<MessageRoomViewModel>>
    {
        public string UserId { get; set; }
    }

    public class GetMessageRoomsQueryHandler : IRequestHandler<GetMessageRoomsQuery,IEnumerable<MessageRoomViewModel>>
    {
        private readonly IMessageRoomRepository _messageRoomRepository;
        private readonly IMapper _mapper;
        public GetMessageRoomsQueryHandler(IMessageRoomRepository messageRoomRepository, IMapper mapper)
        {
            _messageRoomRepository = messageRoomRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageRoomViewModel>> Handle(GetMessageRoomsQuery request, CancellationToken cancellationToken)
        {
            var messageRooms = await _messageRoomRepository.GetMessageRooms(request.UserId);
            return _mapper.Map<IEnumerable<MessageRoomViewModel>>(messageRooms);
        }
    }

    public class GetMessageRoomsQueryValidator : AbstractValidator<GetMessageRoomsQuery>
    {
        public GetMessageRoomsQueryValidator()
        {
            RuleFor(m => m.UserId).NotNull();
        }
    }
}
