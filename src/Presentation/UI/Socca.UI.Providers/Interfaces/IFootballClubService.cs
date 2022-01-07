using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.UI.Providers.DTOs;

namespace Socca.UI.Providers.Interfaces
{
    public interface IFootballClubService
    {
        Task<List<FootballClub>> GetFootballClubs();

        Task<string> AddFootballClubs(FootballClub footballClub);

        Task<string> LinkToStadium(AssignToStadium assignToStadium);
    }
}
