using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Socca.Domain.Core.Bus;
using Microsoft.Extensions.Configuration;
using Socca.Players.Domain.ProjectAggregate.Commands;
using Socca.Players.Domain.Events;

namespace Socca.Players.Domain.CommandHandlers
{

    public class PlayerTransferCommandHandler : IRequestHandler<CreatePlayerTransferCommand, bool>
    {
        private readonly IEventBus _bus;
        private readonly IConfiguration _configuration;

        public PlayerTransferCommandHandler(IEventBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }


        public Task<bool> Handle(CreatePlayerTransferCommand request, CancellationToken cancellationToken)
        {
            // publish event to RabbitMq
            _bus.Publish(new PlayerTransferCreatedEvent(request.From, request.To, request.PlayerId), _configuration.GetConnectionString("RabbitMqConnectionString"));
            return Task.FromResult(true);
        }
    }
}
