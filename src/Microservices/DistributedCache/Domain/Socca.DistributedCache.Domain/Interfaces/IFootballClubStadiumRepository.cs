using System.Threading.Tasks;
using Socca.DistributedCache.Domain.Entities;

namespace Socca.DistributedCache.Domain.Interfaces
{
    public interface IFootballClubStadiumRepository
    {
        Task<FootballClubStadium> GetFootballClubStadium(int footballClubId);
        Task<FootballClubStadium> UpdateFootballClubStadium(FootballClubStadium player);
        Task DeleteFootballClubStadium(int footballClubId);
    }
}
