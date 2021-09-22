using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatA.WebUI.Models
{
    public class AddUserToGroupMessageRoomModel
    {
        public int RoomId { get; set; }
        public string UserId { get; set; }
    }
}
