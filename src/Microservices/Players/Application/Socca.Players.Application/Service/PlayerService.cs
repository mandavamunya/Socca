using System.Collections.Generic;
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

        public void AddPlayer(Player player)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Player> GetPlayers()
        {
            throw new System.NotImplementedException();
        }

        public void Transfer(PlayerTransfer playerTransfer)
        {
            throw new System.NotImplementedException();
        }
    }
}
