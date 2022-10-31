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
        Task<Domain.Entities.FootballClub> GetFootballClubByName(string name);
        Task<Domain.Entities.FootballClub> Get(int id);
        Task Update(Domain.Entities.FootballClub footballClub);
        Task Remove(Domain.Entities.FootballClub footballClub);
    }
}
