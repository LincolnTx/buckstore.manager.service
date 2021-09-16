using System.Threading;
using System.Threading.Tasks;
using buckstore.manager.service.application.IntegrationEvents;

namespace buckstore.manager.service.application.EventHandlers.Integration
{
    public class StockUpdateIntegrationEventHandler : EventHandler<StockUpdateIntegrationEvent>
    {
        public override Task Handle(StockUpdateIntegrationEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
