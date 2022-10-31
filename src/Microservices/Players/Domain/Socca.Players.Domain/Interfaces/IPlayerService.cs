using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.Players.Domain.Models;
using Socca.Players.Domain.Entities;

namespace Socca.Players.Domain.Interfaces
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetPlayers();
        Task AddPlayer(Player player);
        Task Transfer(PlayerTransfer playerTransfer);
        Task<Domain.Entities.Player> Get(int id);
        Task Update(Domain.Entities.Player footballClub);
        Task Remove(Domain.Entities.Player footballClub);
    }
}
