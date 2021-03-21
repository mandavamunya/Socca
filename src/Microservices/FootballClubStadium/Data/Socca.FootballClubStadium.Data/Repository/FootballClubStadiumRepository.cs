using System;
using System.Threading.Tasks;
using Socca.FootballClubStadium.Domain.Interfaces;

namespace Socca.FootballClubStadium.Data.Repository
{
    public class FootballClubStadiumRepository: IFootballClubStadiumRepository
    {
        public FootballClubStadiumRepository()
        {
        }

        public Task Add(Domain.Entities.FootballClubStadium stadium)
        {
            throw new NotImplementedException();
        }
    }
}
