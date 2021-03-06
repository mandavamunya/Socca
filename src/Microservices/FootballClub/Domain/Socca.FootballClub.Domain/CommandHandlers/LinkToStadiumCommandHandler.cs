using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Socca.Domain.Core.Bus;
using Socca.FootballClub.Domain.Commands;
using Socca.FootballClub.Domain.Events;

namespace Socca.FootballClub.Domain.CommandHandlers
{
    public class LinkToStadiumCommandHandler : IRequestHandler<CreateLinkToStadiumCommand, bool>
    {
        private readonly IEventBus _bus;
        public LinkToStadiumCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateLinkToStadiumCommand request, CancellationToken cancellationToken)
        {
            // publish event to RabbitMq
            _bus.Publish(new LinkToStadiumCreatedEvent(request.FootballClubId, request.StadiumId));
            return Task.FromResult(true);
        }
    }
}
