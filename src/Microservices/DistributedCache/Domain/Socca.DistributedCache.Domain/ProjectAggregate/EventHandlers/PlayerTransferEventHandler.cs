using System.Threading.Tasks;
using Socca.DistributedCache.Domain.Constants;
using Socca.DistributedCache.Domain.Entities;
using Socca.DistributedCache.Domain.Interfaces;
using Socca.DistributedCache.Domain.ProjectAggregate.Events;
using Socca.Domain.Core.Bus;

namespace Socca.DistributedCache.Domain.ProjectAggregate.EventHandlers
{
    public class PlayerTransferEventHandler : IEventHandler<PlayerTransferCreatedEvent>
    {
        private readonly IDistributedCacheRepository<PlayerTransfer> _repository;

        public PlayerTransferEventHandler(IDistributedCacheRepository<PlayerTransfer> repository)
        {
            _repository = repository;
        }

        public async Task Handle(PlayerTransferCreatedEvent @event)
        {
            await _repository.Update($"{ServiceNameConstant.PlayerTransfer}-{@event.PlayerId.ToString()}",
            new PlayerTransfer()
            {
                FromTeam = @event.From,
                ToTeam = @event.To,
                PlayerId = @event.PlayerId,
                Timestamp = @event.Timestamp
            });
        }
    }
}
