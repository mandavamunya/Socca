using System.Threading.Tasks;
using Socca.FootballClub.Domain.Interfaces;

namespace Socca.FootballClub.Data.Repository
{
    public class FootballClubRepository: IFootballClubRepository
    {
        public FootballClubRepository()
        {
        }

        public Task Add(Domain.Entities.FootballClub footballClub)
        {
            throw new System.NotImplementedException();
        }
    }
}
