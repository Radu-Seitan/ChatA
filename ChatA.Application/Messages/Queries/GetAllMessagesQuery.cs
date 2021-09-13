using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChatA.Application.Common.Interfaces;
using ChatA.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.Messages.Queries
{
    public class GetAllMessagesQuery : IRequest<IEnumerable<MessageViewModel>>
    {
        public int MessageRoomId { get; set; }
    }

    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery,IEnumerable<MessageViewModel>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        public GetAllMessagesQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageViewModel>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages =  await _messageRepository.GetMessages(request.MessageRoomId) as IQueryable;
            return messages.ProjectTo<MessageViewModel>(_mapper.ConfigurationProvider);
        }
    }
}
