using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Socca.Domain.Core.Bus;
using Socca.Infrastructure.Bus;

namespace Socca.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp => {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });
        }

    }
}
