using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.Domain.Core.Bus;
using Socca.Players.Domain.ProjectAggregate.Commands;
using Socca.Players.Domain.Interfaces;
using Socca.Players.Domain.Models;
using Socca.Players.Domain.Entities;
using Socca.Domain.Core.Interfaces;
using Socca.Domain.Core.GuardClause;

namespace Socca.Players.Domain.Service
{
    public class PlayerService: IPlayerService
    {
        private readonly IAsyncRepository<Entities.Player> _asyncRepository;
        private readonly IEventBus _bus;
        public PlayerService(IAsyncRepository<Entities.Player> asyncRepository, IEventBus bus)
        {
            _asyncRepository = asyncRepository;
            _bus = bus;
        }

        public async Task AddPlayer(Player player)
        {
            await _asyncRepository.AddAsync(player);
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _asyncRepository.ListAllAsync();
        }

        public async Task Transfer(PlayerTransfer playerTransfer)
        {

            var player = await _asyncRepository.GetByIdAsync(playerTransfer.PlayerId);

            // Player record might have been removed by another process just before being transfer
            Guard.Against.NullPlayer(playerTransfer.PlayerId, player); // Therefore: Fail Fast

            var command = new CreatePlayerTransferCommand(
                playerTransfer.FromTeam,
                playerTransfer.ToTeam,
                playerTransfer.PlayerId);

            await _bus.SendCommand(command);
        }

        public async Task<Entities.Player> Get(int id)
        {
            return await _asyncRepository.GetByIdAsync(id);
        }

        public async Task Update(Entities.Player player)
        {
            await _asyncRepository.UpdateAsync(player);
        }

        public async Task Remove(Entities.Player player)
        {
            await _asyncRepository.DeleteAsync(player);
        }
    }
}
