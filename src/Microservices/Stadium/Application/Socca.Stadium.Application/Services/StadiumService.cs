using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.Stadium.Application.Interfaces;
using Socca.Stadium.Domain.Interfaces;

namespace Socca.Stadium.Application.Services
{
    public class StadiumService: IStadiumService
    {
        private readonly IStadiumRepository _repository;
        public StadiumService(IStadiumRepository repository)
        {
            _repository = repository;
        }

        public async Task AddStadium(Domain.Entities.Stadium stadium)
        {
            await _repository.Add(stadium);
        }

        public async Task<IEnumerable<Domain.Entities.Stadium>> GetStadiums()
        {
            return await _repository.GetStadium();
        }
    }
}
