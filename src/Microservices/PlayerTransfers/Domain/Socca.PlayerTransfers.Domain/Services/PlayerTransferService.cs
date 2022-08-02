using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.PlayerTransfers.Domain.Entities;
using Socca.PlayerTransfers.Domain.Interfaces;

namespace Socca.PlayerTransfers.Domain.Services
{
    public class PlayerTransferService: IPlayerTransferService
    {
        private readonly IPlayerTransferRepository _repository;

        public PlayerTransferService(IPlayerTransferRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlayerTransfer>> GetPlayerTransfers()
        {
            return await _repository.Get();
        }
    }
}
