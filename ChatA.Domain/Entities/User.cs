using System;
using System.Collections.Generic;

namespace ChatA.Domain.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Guid? ImageId { get; set; }
        public AppImage Image { get; set; }
        public List<Membership> Memberships { get; set; }
    }
}
