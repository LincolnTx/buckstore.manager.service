using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using buckstore.manager.service.application.IntegrationEvents;
using buckstore.manager.service.application.Adapters.MessageBroker;

namespace buckstore.manager.service.application.EventHandlers.Integration
{
    public class ProductUpdatedEventHandler : EventHandler<ProductUpdatedIntegrationEvent>
    {
        private readonly IMessageProducer<ProductUpdatedIntegrationEvent> _messageProducer;
        private readonly ILogger<ProductUpdatedEventHandler> _logger;

        public ProductUpdatedEventHandler(IMessageProducer<ProductUpdatedIntegrationEvent> messageProducer, ILogger<ProductUpdatedEventHandler> logger)
        {
            _messageProducer = messageProducer;
            _logger = logger;
        }

        public override async Task Handle(ProductUpdatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _messageProducer.Produce(notification);
            _logger.LogInformation($"O Produto {notification.Name} de id = {notification.Id} foi atualizado e enviado para a api de products");
        }
    }
}
