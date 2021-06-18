using MediatR;
using Microsoft.Extensions.Logging;
using buckstore.manager.service.application.IntegrationEvents;

namespace buckstore.manager.service.bus.MessageBroker.Kafka.Consumer
{
    public class OrderReceivedConsumer : KafkaConsumer<OrderReceivedIntegrationEvent>
    {
        public OrderReceivedConsumer(IMediator bus, ILogger logger) : base(bus, logger)
        {
        }
    }
}