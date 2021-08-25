using ChatA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface IMessageRepository
    {
        void CreateMessage(Message message);
        IEnumerable<Message> GetMessages(MessageRoom messageRoom);
        Message GetMessage(int messageId);
    }
}
