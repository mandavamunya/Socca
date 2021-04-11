using System.Threading.Tasks;
using Socca.DistributedCache.Domain.Entities;

namespace Socca.DistributedCache.Domain.Interfaces
{
    public interface IPlayerTransferService
    {
        Task<PlayerTransfer> Get(int key);
    }
}
