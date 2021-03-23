using System.Collections.Generic;
using System.Threading.Tasks;

namespace Socca.FootballClubStadium.Application.Interfaces
{
    public interface IFootballClubStadiumService
    {
        Task<IEnumerable<Domain.Entities.FootballClubStadium>> Get();
    }
}
