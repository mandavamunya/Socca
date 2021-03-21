using System.Threading.Tasks;

namespace Socca.FootballClubStadium.Domain.Interfaces
{
    public interface IFootballClubStadiumRepository
    {
        Task Add(Entities.FootballClubStadium stadium);
    }
}
