using System;
using System.Collections.Generic;

namespace buckstore.manager.service.application.IntegrationEvents
{
    public class OrderReceivedIntegrationEvent : IntegrationEvent
    {
        public IEnumerable<ProductsFromOrderDto> OrderProducts { get; set; }

        public OrderReceivedIntegrationEvent() : base(DateTime.Now)
        {
        }
    }
    
    public class ProductsFromOrderDto
    {
        public Guid ProductId { get; set; }
        public int QuantitySold { get; set; }
    }
}