using System.Threading.Tasks;
using Socca.Domain.Core.Bus;
using Socca.FootballClubStadium.Application.Events;
using Socca.FootballClubStadium.Domain.Interfaces;

namespace Socca.FootballClubStadium.Application.EventHandlers
{
    public class LinkToStadiumEventHandler : IEventHandler<LinkToStadiumCreatedEvent>
    {
        private readonly IFootballClubStadiumRepository _repository;

        public LinkToStadiumEventHandler(IFootballClubStadiumRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(LinkToStadiumCreatedEvent @event)
        {
            _repository.Add(new Domain.Entities.FootballClubStadium()
            {
                FootballClubId = @event.FootballClubId,
                StadiumId = @event.StadiumId
            });

            return Task.CompletedTask;
        }
    }
}
