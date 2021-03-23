using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.PlayerTransfers.Domain.Entities;

namespace Socca.PlayerTransfers.Domain.Interfaces
{
    public interface IPlayerTransferRepository
    {
        Task Add(Entities.PlayerTransfer playerTransfer);
        Task Update(Entities.PlayerTransfer playerTransfer);
        Task<IEnumerable<PlayerTransfer>> Get();
    }
}
