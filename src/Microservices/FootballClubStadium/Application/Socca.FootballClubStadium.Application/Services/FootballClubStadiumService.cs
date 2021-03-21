using System;
using System.Threading.Tasks;
using Socca.FootballClubStadium.Application.Interfaces;

namespace Socca.FootballClubStadium.Application.Services
{
    public class FootballClubStadiumService: IFootballClubStadiumService
    {
        public FootballClubStadiumService()
        {
        }

        public Task AddFootballClubStadium(Domain.Entities.FootballClubStadium stadium)
        {
            throw new NotImplementedException();
        }
    }
}
