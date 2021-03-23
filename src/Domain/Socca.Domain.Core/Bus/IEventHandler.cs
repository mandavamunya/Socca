using System.Threading.Tasks;
using Socca.Domain.Core.Events;

namespace Socca.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent: Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
