using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.Domain.Core.Bus;
using Socca.Players.Domain.ProjectAggregate.Commands;
using Socca.Players.Domain.Interfaces;
using Socca.Players.Domain.Models;
using Socca.Players.Domain.Entities;

namespace Socca.Players.Domain.Service
{
    public class PlayerService: IPlayerService
    {
        private readonly IPlayerRepository _repository;
        private readonly IEventBus _bus;
        public PlayerService(IPlayerRepository repository, IEventBus bus)
        {
            _repository = repository;
            _bus = bus;
        }

        public async Task AddPlayer(Player player)
        {
            await _repository.Add(player);
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _repository.Get();
        }

        public async Task Transfer(PlayerTransfer playerTransfer)
        {
            var command = new CreatePlayerTransferCommand(
                playerTransfer.FromTeam,
                playerTransfer.ToTeam,
                playerTransfer.PlayerId);

            await _bus.SendCommand(command);
        }
    }
}
