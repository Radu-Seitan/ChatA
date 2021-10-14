using ChatA.Application.Common.Interfaces;
using ChatA.WebUI.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatA.WebUI.Services
{
    public abstract class SignalRNotifier<T> : INotifier<T>
    {
        protected readonly IHubContext<ChatHub> HubContext;
        public SignalRNotifier(IHubContext<ChatHub> hubContext)
        {
            HubContext = hubContext;
        }
        public abstract Task Notify(T @event);
    }
}
