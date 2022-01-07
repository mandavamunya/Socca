using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.FootballClubStadium.Application.Interfaces;
using Socca.FootballClubStadium.Domain.Interfaces;

namespace Socca.FootballClubStadium.Application.Services
{
    public class FootballClubStadiumService: IFootballClubStadiumService
    {
        private readonly IFootballClubStadiumRepository _repository;
        public FootballClubStadiumService(IFootballClubStadiumRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<Domain.Entities.FootballClubStadium>> Get()
        {
            return await _repository.Get();
        }
    }
}
