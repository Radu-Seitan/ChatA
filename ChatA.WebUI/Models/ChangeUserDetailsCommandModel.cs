using System;

namespace ChatA.WebUI.Models
{
    public class ChangeUserDetailsCommandModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public Guid? ImageId { get; set; }
    }
}
