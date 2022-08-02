using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Socca.Domain.Core.Bus;
using Socca.FootballClub.Domain.ProjectAggregate.Commands;
using Socca.FootballClub.Domain.ProjectAggregate.Events;

namespace Socca.FootballClub.Domain.ProjectAggregate.CommandHandlers
{
    public class LinkToStadiumCommandHandler : IRequestHandler<CreateLinkToStadiumCommand, bool>
    {
        private readonly IEventBus _bus;
        private readonly IConfiguration _configuration;
        public LinkToStadiumCommandHandler(IEventBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        public Task<bool> Handle(CreateLinkToStadiumCommand request, CancellationToken cancellationToken)
        {
            // publish event to RabbitMq
            _bus.Publish(new LinkToStadiumCreatedEvent(request.FootballClubId, request.StadiumId), _configuration.GetConnectionString("RabbitMq:Connection"));
            return Task.FromResult(true);
        }
    }
}
