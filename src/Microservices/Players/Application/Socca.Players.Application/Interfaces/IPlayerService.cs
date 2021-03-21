using System.Collections.Generic;
using Socca.Players.Application.Models;
using Socca.Players.Domain.Entities;

namespace Socca.Players.Application.Interfaces
{
    public interface IPlayerService
    {
        IEnumerable<Player> GetPlayers();
        void AddPlayer(Player player);
        void Transfer(PlayerTransfer playerTransfer);
    }
}
