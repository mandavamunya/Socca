using System.Threading.Tasks;
using Socca.Domain.Core.Bus;
using Socca.PlayerTransfers.Domain.Entities;
using Socca.PlayerTransfers.Domain.Interfaces;
using Socca.PlayerTransfers.Domain.ProjectAggregate.Events;

namespace Socca.PlayerTransfers.Domain.ProjectAggregate.EventHandlers
{
    public class PlayerTransferEventHandler : IEventHandler<PlayerTransferCreatedEvent>
    {
        private readonly IPlayerTransferRepository _playerTransferRepository;

        public PlayerTransferEventHandler(IPlayerTransferRepository playerTransferRepository)
        {
            _playerTransferRepository = playerTransferRepository;
        }

        public async Task Handle(PlayerTransferCreatedEvent @event)
        {
            await _playerTransferRepository.Add(new PlayerTransfer()
            {
                FromTeam = @event.From,
                ToTeam = @event.To,
                PlayerId = @event.PlayerId,
                DateCreated = @event.Timestamp
            });
        }
    }

}
