using System.Threading.Tasks;
using Socca.Domain.Core.Bus;
using Socca.PlayerTransfers.Application.Events;
using Socca.PlayerTransfers.Domain.Entities;
using Socca.PlayerTransfers.Domain.Interfaces;

namespace Socca.PlayerTransfers.Application.EventHandlers
{
    public class PlayerTransferEventHandler : IEventHandler<PlayerTransferCreatedEvent>
    {
        private readonly IPlayerTransferRepository _playerTransferRepository;

        public PlayerTransferEventHandler(IPlayerTransferRepository playerTransferRepository)
        {
            _playerTransferRepository = playerTransferRepository;
        }

        public Task Handle(PlayerTransferCreatedEvent @event)
        {
            _playerTransferRepository.Add(new PlayerTransfer()
            {
                FromTeam = @event.From,
                ToTeam = @event.To,
                PlayerId = @event.PlayerId,
            });

            return Task.CompletedTask;
        }
    }

}
