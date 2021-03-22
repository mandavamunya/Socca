using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.Players.Application.Interfaces;
using Socca.Players.Application.Models;
using Socca.Players.Domain.Entities;
using Socca.Players.Domain.Interfaces;

namespace Socca.Players.Application.Service
{
    public class PlayerService: IPlayerService
    {
        private readonly IPlayerRepository _repository;
        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
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
            // send command to PlayerTransfer service
        }
    }
}
