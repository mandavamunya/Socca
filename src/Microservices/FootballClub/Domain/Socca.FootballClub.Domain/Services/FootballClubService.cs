using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Socca.Domain.Core.Bus;
using Socca.Domain.Core.GuardClause;
using Socca.Domain.Core.Interfaces;
using Socca.FootballClub.Domain.Interfaces;
using Socca.FootballClub.Domain.Models;
using Socca.FootballClub.Domain.ProjectAggregate.Commands;
using Socca.FootballClub.Domain.ProjectAggregate.Specifications;

namespace Socca.FootballClub.Domain.Services
{
    public class FootballClubService: IFootballClubService
    {
        private readonly IAsyncRepository<Entities.FootballClub> _asyncRepository;
        private readonly IEventBus _bus;
        public FootballClubService(IAsyncRepository<Entities.FootballClub> asyncRepository, IEventBus bus)
        {
            _asyncRepository = asyncRepository;
            _bus = bus;
        }

        public async Task AddFootballClub(Domain.Entities.FootballClub footballClub)
        {
            await _asyncRepository.AddAsync(footballClub);
        }

        public async Task<IEnumerable<Domain.Entities.FootballClub>> GetFootballClubs()
        {
            return await _asyncRepository.ListAllAsync();
        }

        public async Task AssignToStadium(AssignToStadium assignToStadium)
        {
            var footballClub = await _asyncRepository.GetByIdAsync(assignToStadium.FootballClubId);

            // FootballClub record might have been removed by another process just before assigning it to a Stadium
            Guard.Against.NullFootballClub(assignToStadium.FootballClubId, footballClub); // Therefore: Fail Fast
            
            var command = new CreateLinkToStadiumCommand(
                assignToStadium.FootballClubId,
                assignToStadium.StadiumId);

            await _bus.SendCommand(command);
        }

        public async Task<Entities.FootballClub> GetFootballClubByName(string name)
        {
            var spec = new FootballClubByNameSpec(name);
            // This is just anexample. Use a specification to get a lookup given a certain Id or key
            var footballClubs = await _asyncRepository.ListAsync((ISpecification<Entities.FootballClub>)spec); 
            var footballClub = footballClubs.FirstOrDefault();
            // In case of a get http request you can choose to return null value
            // Or to fail fast depending on the business requeirements
            // To fail fast comment out the following line
            //Guard.Against.NullFootballClub(name, footballClub); 
            return footballClub;
        }

        public async Task<Entities.FootballClub> Get(int id)
        {
            return await _asyncRepository.GetByIdAsync(id);
        }

        public async Task Update(Entities.FootballClub footballClub)
        {
            await _asyncRepository.UpdateAsync(footballClub);
        }

        public async Task Remove(Entities.FootballClub footballClub)
        {
            await _asyncRepository.DeleteAsync(footballClub);
        }
    }
}
