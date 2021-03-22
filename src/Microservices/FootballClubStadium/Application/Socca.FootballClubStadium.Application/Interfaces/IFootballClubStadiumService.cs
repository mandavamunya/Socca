using System.Collections.Generic;
using System.Threading.Tasks;

namespace Socca.FootballClubStadium.Application.Interfaces
{
    public interface IFootballClubStadiumService
    {
        Task AddFootballClubStadium(Domain.Entities.FootballClubStadium stadium);
        Task<IEnumerable<Domain.Entities.FootballClubStadium>> Get();
    }
}
