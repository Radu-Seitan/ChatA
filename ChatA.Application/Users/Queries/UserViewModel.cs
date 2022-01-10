using ChatA.Application.Common.Mappings;
using ChatA.Domain.Entities;
using System;

namespace ChatA.Application.Users.Queries
{
    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Guid? ImageId { get; set; }
    }
}
