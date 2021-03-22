using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.FootballClub.Application.Interfaces;
using Socca.FootballClub.Application.Models;
using Socca.FootballClub.Domain.Interfaces;

namespace Socca.FootballClub.Application.Services
{
    public class FootballClubService: IFootballClubService
    {
        private readonly IFootballClubRepository _repository;
        public FootballClubService(IFootballClubRepository repository)
        {
            _repository = repository;
        }

        public async Task AddFootballClub(Domain.Entities.FootballClub footballClub)
        {
            await _repository.Add(footballClub);
        }

        public async Task AssignToStadium(AssignToStadium assignToStadium)
        {
            // send AssignToStadium command to FootballClubStadium service
        }

        public async Task<IEnumerable<Domain.Entities.FootballClub>> GetFootballClubs()
        {
            return await _repository.Get();
        }
    }
}
