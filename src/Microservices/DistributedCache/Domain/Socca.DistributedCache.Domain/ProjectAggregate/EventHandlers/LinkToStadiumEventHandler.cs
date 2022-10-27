using System.Threading.Tasks;
using Socca.DistributedCache.Domain.Constants;
using Socca.DistributedCache.Domain.Entities;
using Socca.DistributedCache.Domain.Interfaces;
using Socca.DistributedCache.Domain.ProjectAggregate.Events;
using Socca.Domain.Core.Bus;

namespace Socca.DistributedCache.Domain.ProjectAggregate.EventHandlers
{
    public class LinkToStadiumEventHandler : IEventHandler<LinkToStadiumCreatedEvent>
    {
        private readonly IDistributedCacheRepository<FootballClubStadium> _repository;

        public LinkToStadiumEventHandler(IDistributedCacheRepository<FootballClubStadium> repository)
        {
            _repository = repository;
        }

        public async Task Handle(LinkToStadiumCreatedEvent @event)
        {
            await _repository.Update(
            $"{ServiceNameConstant.FootballClubStadium}-{@event.FootballClubId.ToString()}",
            new FootballClubStadium()
            {
                FootballClubId = @event.FootballClubId,
                StadiumId = @event.StadiumId,
                Timestamp = @event.Timestamp
            });

        }
    }
}
