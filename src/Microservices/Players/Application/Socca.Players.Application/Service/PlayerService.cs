using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.Domain.Core.Bus;
using Socca.Players.Application.Commands;
using Socca.Players.Application.Interfaces;
using Socca.Players.Application.Models;
using Socca.Players.Domain.Entities;
using Socca.Players.Domain.Interfaces;

namespace Socca.Players.Application.Service
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
