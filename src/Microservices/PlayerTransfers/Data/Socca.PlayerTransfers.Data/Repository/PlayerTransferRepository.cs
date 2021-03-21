using System.Threading.Tasks;
using Socca.PlayerTransfers.Domain.Entities;
using Socca.PlayerTransfers.Domain.Interfaces;

namespace Socca.PlayerTransfers.Data.Repository
{
    public class PlayerTransferRepository: IPlayerTransferRepository
    {
        public PlayerTransferRepository()
        {
        }

        public Task Add(PlayerTransfer playerTransfer)
        {
            throw new System.NotImplementedException();
        }
    }
}
