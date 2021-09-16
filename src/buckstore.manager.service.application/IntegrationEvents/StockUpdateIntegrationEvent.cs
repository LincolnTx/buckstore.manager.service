using System;
using System.Collections.Generic;
using buckstore.manager.service.application.Adapters.MessageBroker.Dtos;

namespace buckstore.manager.service.application.IntegrationEvents
{
    public class StockUpdateIntegrationEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
        public IEnumerable<StockUpdateItemsDto> Products  { get; set; }

        public StockUpdateIntegrationEvent() : base(DateTime.Now)
        {
        }
    }
}
