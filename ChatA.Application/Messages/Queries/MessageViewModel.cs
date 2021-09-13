using AutoMapper;
using ChatA.Application.Common.Mappings;
using ChatA.Domain.Entities;
using System;

namespace ChatA.Application.Messages.Queries
{
    public class MessageViewModel :IMapFrom<Message>
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Username { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Message, MessageViewModel>()
                .ForMember(d => d.Username,opt => opt.MapFrom(m => m.Sender.Username));
        }
    }
}
