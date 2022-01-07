using System.Threading.Tasks;
using Socca.DistributedCache.Domain.Constants;
using Socca.DistributedCache.Domain.Entities;
using Socca.DistributedCache.Domain.Interfaces;

namespace Socca.DistributedCache.Application.Services
{
    public class PlayerTransferService: IPlayerTransferService
    {
        private readonly IDistributedCacheRepository<PlayerTransfer> _repository;
        public PlayerTransferService(IDistributedCacheRepository<PlayerTransfer> repository)
        {
            _repository = repository;
        }

        public async Task<PlayerTransfer> Get(int key)
        {
            return await _repository.Get($"{ServiceNameConstant.FootballClubStadium}-{key}");
        }
    }
}
