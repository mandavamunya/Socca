using System.Threading.Tasks;
using Socca.DistributedCache.Domain.Entities;

namespace Socca.DistributedCache.Domain.Interfaces
{
    public interface IPlayerTransferRepository
    {
        Task<PlayerTransfer> GetPlayerTransfer(int playerId);
        Task<PlayerTransfer> UpdatePlayerTransfer(PlayerTransfer playerTransfer);
        Task DeletePlayerTransfer(int playerId);
    }
}
