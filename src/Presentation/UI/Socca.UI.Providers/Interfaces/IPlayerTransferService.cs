using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.UI.Providers.DTOs;

namespace Socca.UI.Providers.Interfaces
{
    public interface IPlayerTransferService
    {
        Task<PlayerTransfer> GetPlayerTransfer(int key);

        Task<List<PlayerTransfer>> GetPlayerTransfers();
    }
}
