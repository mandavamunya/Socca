using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.Domain.Core.Bus;
using Socca.FootballClub.Application.Interfaces;
using Socca.FootballClub.Application.Models;
using Socca.FootballClub.Domain.Commands;
using Socca.FootballClub.Domain.Interfaces;

namespace Socca.FootballClub.Application.Services
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
            ///
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
