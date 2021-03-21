using System.Threading.Tasks;

namespace Socca.PlayerTransfers.Domain.Interfaces
{
    public interface IPlayerTransferRepository
    {
        Task Add(Domain.Entities.PlayerTransfer playerTransfer);
    }
}
