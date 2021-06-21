using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using buckstore.manager.service.application.IntegrationEvents;
using buckstore.manager.service.application.Adapters.MessageBroker;

namespace buckstore.manager.service.application.EventHandlers.Integration
{
    public class ProductDeletedEventHandler : EventHandler<ProductDeletedIntegrationEvent>
    {
        private readonly IMessageProducer<ProductDeletedIntegrationEvent> _messageProducer;
        private readonly ILogger<ProductDeletedEventHandler> _logger;

        public ProductDeletedEventHandler(IMessageProducer<ProductDeletedIntegrationEvent> messageProducer, ILogger<ProductDeletedEventHandler> logger)
        {
            _messageProducer = messageProducer;
            _logger = logger;
        }

        public override async Task Handle(ProductDeletedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _messageProducer.Produce(notification);
            _logger.LogInformation($"O Produto de id = {notification.Id} foi deletado e enviado pra a api de products");
        }
    }
}
