using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Socca.Domain.Core.Bus;
using Socca.Players.Domain.Commands;
using Socca.Players.Domain.Events;

namespace Socca.Players.Domain.CommandHandlers
{

    public class PlayerTransferCommandHandler : IRequestHandler<CreatePlayerTransferCommand, bool>
    {
        private readonly IEventBus _bus;

        public PlayerTransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreatePlayerTransferCommand request, CancellationToken cancellationToken)
        {
            // publish event to RabbitMq
            _bus.Publish(new PlayerTransferCreatedEvent(request.From, request.To, request.PlayerId));
            return Task.FromResult(true);
        }
    }
}
