using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.PlayerTransfers.Domain.Entities;

namespace Socca.PlayerTransfers.Application.Interfaces
{
    public interface IPlayerTransferService
    {
        Task<IEnumerable<PlayerTransfer>> GetPlayerTransfers();
        Task AddPlayer(Domain.Entities.PlayerTransfer playerTransfer);
    }
}
