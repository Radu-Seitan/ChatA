using AutoMapper;
using ChatA.Application.Common.Mappings;
using ChatA.Domain.Entities;
using System;

namespace ChatA.Application.Messages.Queries
{
    public class MessageViewModel :IMapFrom<Message>
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string SentBy { get; set; }
        public string SenderId { get; set; }
        public string Text { get; set; }
        public int RoomId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Message, MessageViewModel>()
                .ForMember(d => d.SentBy,opt => opt.MapFrom(m => m.Sender.Username));
        }
    }
}
