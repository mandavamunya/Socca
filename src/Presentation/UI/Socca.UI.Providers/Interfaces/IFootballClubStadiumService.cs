using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.UI.Providers.DTOs;

namespace Socca.UI.Providers.Interfaces
{
    public interface IFootballClubStadiumService
    {
        Task<List<FootballClubStadium>> GetFootballClubs();
    }
}
