using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using buckstore.manager.service.application.IntegrationEvents;
using buckstore.manager.service.application.Adapters.MessageBroker;

namespace buckstore.manager.service.application.EventHandlers.Integration
{
    public class ProductCreatedEventHandler : EventHandler<ProductCreatedIntegrationEvent>
    {
        private readonly IMessageProducer<ProductCreatedIntegrationEvent> _messageProducer;
        private readonly ILogger<ProductCreatedEventHandler> _logger;

        public ProductCreatedEventHandler(IMessageProducer<ProductCreatedIntegrationEvent> messageProducer, ILogger<ProductCreatedEventHandler> logger)
        {
            _messageProducer = messageProducer;
            _logger = logger;
        }

        public override async Task Handle(ProductCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _messageProducer.Produce(notification);
            _logger.LogInformation($"O produto {notification.Name} de id = {notification.Id} foi criado e enviado para a api de products");
        }
    }
}
