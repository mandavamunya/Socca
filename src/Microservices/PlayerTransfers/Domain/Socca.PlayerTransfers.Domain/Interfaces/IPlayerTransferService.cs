using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.PlayerTransfers.Domain.Entities;

namespace Socca.PlayerTransfers.Domain.Interfaces
{
    public interface IPlayerTransferService
    {
        Task<IEnumerable<PlayerTransfer>> GetPlayerTransfers();
    }
}
