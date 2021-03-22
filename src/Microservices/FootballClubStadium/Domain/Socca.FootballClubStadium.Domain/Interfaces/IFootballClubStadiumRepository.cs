using System.Collections.Generic;
using System.Threading.Tasks;

namespace Socca.FootballClubStadium.Domain.Interfaces
{
    public interface IFootballClubStadiumRepository
    {
        Task Add(Entities.FootballClubStadium stadium);
        Task<IEnumerable<Entities.FootballClubStadium>> Get();
    }
}
