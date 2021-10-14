using ChatA.Application.MessageRooms.Queries;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatA.WebUI.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediator;
        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        private async Task JoinRoom(int roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }
        private async Task LeaveRoom(int roomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());
        }
        public override async Task OnConnectedAsync()
        {
            var rooms = await _mediator.Send(new GetMessageRoomsQuery { UserId = Context.UserIdentifier });
            foreach(var room in rooms)
            {
                await JoinRoom(room.Id);
            }
            await base.OnConnectedAsync();
        }
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            var rooms = await _mediator.Send(new GetMessageRoomsQuery { UserId = Context.UserIdentifier });
            foreach (var room in rooms)
            {
                await LeaveRoom(room.Id);
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
