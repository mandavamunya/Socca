using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.Domain.Core.Bus;
using Socca.FootballClub.Domain.Interfaces;
using Socca.FootballClub.Domain.Models;
using Socca.FootballClub.Domain.ProjectAggregate.Commands;

namespace Socca.FootballClub.Domain.Services
{
    public class FootballClubService: IFootballClubService
    {
        private readonly IFootballClubRepository _repository;
        private readonly IEventBus _bus;
        public FootballClubService(IFootballClubRepository repository, IEventBus bus)
        {
            _repository = repository;
            _bus = bus;
        }

        public async Task AddFootballClub(Domain.Entities.FootballClub footballClub)
        {
            await _repository.Add(footballClub);
        }

        public async Task<IEnumerable<Domain.Entities.FootballClub>> GetFootballClubs()
        {
            return await _repository.Get();
        }

        public async Task AssignToStadium(AssignToStadium assignToStadium)
        {
            var command = new CreateLinkToStadiumCommand(
                assignToStadium.FootballClubId,
                assignToStadium.StadiumId);

            await _bus.SendCommand(command);
        }
    }
}
