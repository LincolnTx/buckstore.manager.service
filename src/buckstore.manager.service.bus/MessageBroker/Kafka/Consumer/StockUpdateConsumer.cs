using MediatR;
using Microsoft.Extensions.Logging;
using buckstore.manager.service.application.IntegrationEvents;

namespace buckstore.manager.service.bus.MessageBroker.Kafka.Consumer
{
    public class StockUpdateConsumer : KafkaConsumer<StockUpdateIntegrationEvent>
    {
        public StockUpdateConsumer(IMediator bus, ILogger<StockUpdateConsumer> logger) : base(bus, logger)
        {
        }
    }
}
