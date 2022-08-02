using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.FootballClub.Domain.Models;

namespace Socca.FootballClub.Domain.Interfaces
{
    public interface IFootballClubService
    {
        Task<IEnumerable<Domain.Entities.FootballClub>> GetFootballClubs();
        Task AddFootballClub(Domain.Entities.FootballClub footballClub);
        Task AssignToStadium(AssignToStadium assignToStadium);
    }
}
