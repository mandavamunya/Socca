using System.Threading.Tasks;
using Socca.DistributedCache.Domain.Entities;

namespace Socca.DistributedCache.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player> GetPlayer(int playerId);
        Task<Player> UpdatePlayer(Player player);
        Task DeletePlayer(int playerId);
    }
}
