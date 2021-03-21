using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.Players.Application.Interfaces;
using Socca.Players.Application.Models;
using Socca.Players.Domain.Entities;

namespace Socca.Players.Application.Service
{
    public class PlayerService: IPlayerService
    {
        public PlayerService()
        {
        }

        public Task AddPlayer(Player player)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Player>> GetPlayers()
        {
            throw new System.NotImplementedException();
        }

        public Task Transfer(PlayerTransfer playerTransfer)
        {
            throw new System.NotImplementedException();
        }
    }
}
