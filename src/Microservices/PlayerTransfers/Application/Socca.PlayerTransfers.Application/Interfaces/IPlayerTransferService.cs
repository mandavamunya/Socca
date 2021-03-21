using System.Threading.Tasks;

namespace Socca.PlayerTransfers.Application.Interfaces
{
    public interface IPlayerTransferService
    {
        Task AddPlayer(Domain.Entities.PlayerTransfer playerTransfer);
    }
}
