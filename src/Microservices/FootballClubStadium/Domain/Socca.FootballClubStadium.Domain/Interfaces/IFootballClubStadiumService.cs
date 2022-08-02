using System.Collections.Generic;
using System.Threading.Tasks;

namespace Socca.FootballClubStadium.Domain.Interfaces
{
    public interface IFootballClubStadiumService
    {
        Task<IEnumerable<Domain.Entities.FootballClubStadium>> Get();
    }
}
