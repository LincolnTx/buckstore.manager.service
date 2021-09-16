using System;
using System.Collections;

namespace buckstore.manager.service.application.IntegrationEvents
{
    public class StockUpdateIntegrationEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
        public IEnumerable StockUpdateItemsDto { get; set; }

        public StockUpdateIntegrationEvent() : base(DateTime.Now)
        {
        }
    }
}
