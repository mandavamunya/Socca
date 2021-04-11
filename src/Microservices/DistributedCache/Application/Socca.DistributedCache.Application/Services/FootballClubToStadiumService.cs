using System.Threading.Tasks;
using Socca.DistributedCache.Domain.Entities;
using Socca.DistributedCache.Domain.Interfaces;

namespace Socca.DistributedCache.Application.Services
{
    public class FootballClubToStadiumService: IFootballClubToStadiumService
    {
        private readonly IDistributedCacheRepository<FootballClubStadium> _repository;
        public FootballClubToStadiumService(IDistributedCacheRepository<FootballClubStadium> repository)
        {
            _repository = repository;
        }

        public async Task<FootballClubStadium> Get(int key)
        {
            return await _repository.Get(string.Format("footballclubTOstadium_{0}", key));
        }
    }
}
