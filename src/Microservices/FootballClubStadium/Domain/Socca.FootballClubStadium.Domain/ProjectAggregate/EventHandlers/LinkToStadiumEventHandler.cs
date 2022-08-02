using System.Threading.Tasks;
using Socca.Domain.Core.Bus;
using Socca.FootballClubStadium.Domain.ProjectAggregate.Events;
using Socca.FootballClubStadium.Domain.Interfaces;

namespace Socca.FootballClubStadium.Domain.ProjectAggregate.EventHandlers
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
                StadiumId = @event.StadiumId,
                DateCreated = @event.Timestamp
            });

            return Task.CompletedTask;
        }
    }
}
