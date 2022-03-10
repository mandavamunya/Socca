using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Socca.Domain.Core.Bus;
using Socca.Players.Application.Commands;
using Socca.Players.Application.Events;
using Microsoft.Extensions.Configuration;

namespace Socca.Players.Application.CommandHandlers
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
