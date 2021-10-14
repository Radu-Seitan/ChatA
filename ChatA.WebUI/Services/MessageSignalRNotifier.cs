using ChatA.Application.Messages.Queries;
using ChatA.Domain.Entities;
using ChatA.WebUI.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatA.WebUI.Services
{
    public class MessageSignalRNotifier : SignalRNotifier<MessageViewModel>
    {
        public MessageSignalRNotifier(IHubContext<ChatHub> hubContext) : base(hubContext)
        {

        }
        public async override Task Notify(MessageViewModel @event)
        {
            await HubContext.Clients
                .Group(@event.RoomId.ToString())
                .SendAsync("ReceiveMessage", JsonSerializer.Serialize(@event, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }));
        }
    }
}
