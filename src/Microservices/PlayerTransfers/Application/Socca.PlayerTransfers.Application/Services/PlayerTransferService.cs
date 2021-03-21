using System.Threading.Tasks;
using Socca.PlayerTransfers.Application.Interfaces;
using Socca.PlayerTransfers.Domain.Entities;

namespace Socca.PlayerTransfers.Application.Services
{
    public class PlayerTransferService: IPlayerTransferService
    {
        public PlayerTransferService()
        {
        }

        public Task AddPlayer(PlayerTransfer playerTransfer)
        {
            throw new System.NotImplementedException();
        }
    }
}
