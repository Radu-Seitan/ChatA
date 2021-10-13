using ChatA.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace ChatA.WebUI.Services
{
    public class SignalRNotifier<T> : INotifier<T>
    {
        public Task Notify(T @event)
        {
            return Task.CompletedTask;
        }
    }
}
