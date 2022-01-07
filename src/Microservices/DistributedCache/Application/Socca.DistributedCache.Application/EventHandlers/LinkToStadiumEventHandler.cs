using System.Threading.Tasks;
using Socca.DistributedCache.Application.Events;
using Socca.DistributedCache.Domain.Constants;
using Socca.DistributedCache.Domain.Entities;
using Socca.DistributedCache.Domain.Interfaces;
using Socca.Domain.Core.Bus;

namespace Socca.DistributedCache.Application.EventHandlers
{
    public class LinkToStadiumEventHandler : IEventHandler<LinkToStadiumCreatedEvent>
    {
        private readonly IDistributedCacheRepository<FootballClubStadium> _repository;

        public LinkToStadiumEventHandler(IDistributedCacheRepository<FootballClubStadium> repository)
        {
            _repository = repository;
        }

        public Task Handle(LinkToStadiumCreatedEvent @event)
        {
            _repository.Update(
            $"{ServiceNameConstant.FootballClubStadium}-{@event.FootballClubId.ToString()}",
            new FootballClubStadium()
            {
                FootballClubId = @event.FootballClubId,
                StadiumId = @event.StadiumId,
                Timestamp = @event.Timestamp
            });

            return Task.CompletedTask;
        }
    }
}
