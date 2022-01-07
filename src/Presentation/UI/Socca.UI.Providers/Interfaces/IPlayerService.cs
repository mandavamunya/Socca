using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.UI.Providers.DTOs;

namespace Socca.UI.Providers.Interfaces
{
    public interface IPlayerService
    {
        Task<List<Player>> GetPlayers();

        Task<string> AddPlayer(Player player);

        Task<string> PlayerTransfer(PlayerTransfer playerTransfer);
    }
}
