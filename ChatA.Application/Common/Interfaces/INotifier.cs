using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface INotifier<T>
    {
        Task Notify(T @event);
    }
}
