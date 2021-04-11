using System.Threading.Tasks;
using Socca.DistributedCache.Domain.Entities;

namespace Socca.DistributedCache.Domain.Interfaces
{
    public interface IFootballClubToStadiumService
    {
        Task<FootballClubStadium> Get(int key);
    }
}
