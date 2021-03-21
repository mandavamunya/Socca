using System.Collections.Generic;
using Socca.Players.Domain.Entities;

namespace Socca.Players.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetPlayer();
        void Add(Player player);
    }
}
