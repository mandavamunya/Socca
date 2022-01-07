using System.Threading.Tasks;
using Socca.UI.Providers.DTOs;

namespace Socca.UI.Providers.Interfaces
{
    public interface IDistributedCacheService
    {
        Task<PlayerTransfer> GetPlayerTransfer(int key);

        Task<FootballClubStadium> GetFootballClubStadium(int key);
    }
}
