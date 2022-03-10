using System.Threading.Tasks;
using Socca.Domain.Core.Events;
using Socca.Domain.Core.Commands;

namespace Socca.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;
        void Publish<T>(T @event, string connectionString) where T : Event;
        void Subscribe<T, TH>(string connectionString) where T : Event
                                where TH : IEventHandler<T>;
    }
}
