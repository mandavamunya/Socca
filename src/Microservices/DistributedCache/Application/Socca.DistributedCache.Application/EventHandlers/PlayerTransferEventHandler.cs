using System.Threading.Tasks;
using Socca.DistributedCache.Application.Events;
using Socca.DistributedCache.Domain.Entities;
using Socca.DistributedCache.Domain.Interfaces;
using Socca.Domain.Core.Bus;

namespace Socca.DistributedCache.Application.EventHandlers
{
    public class PlayerTransferEventHandler : IEventHandler<PlayerTransferCreatedEvent>
    {
        private readonly IDistributedCacheRepository<PlayerTransfer> _repository;

        public PlayerTransferEventHandler(IDistributedCacheRepository<PlayerTransfer> repository)
        {
            _repository = repository;
        }

        public Task Handle(PlayerTransferCreatedEvent @event)
        {
            _repository.Update(
                @event.PlayerId.ToString(),
                new PlayerTransfer()
            {
                FromTeam = @event.From,
                ToTeam = @event.To,
                PlayerId = @event.PlayerId,
            });

            return Task.CompletedTask;
        }
    }
}
