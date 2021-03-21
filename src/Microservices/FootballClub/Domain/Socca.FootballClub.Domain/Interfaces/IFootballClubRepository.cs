using System.Threading.Tasks;

namespace Socca.FootballClub.Domain.Interfaces
{
    public interface IFootballClubRepository
    {
        Task Add(Entities.FootballClub footballClub);
    }
}
