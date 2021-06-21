using System;

namespace buckstore.manager.service.application.IntegrationEvents
{
    public class ProductDeletedIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }

        public ProductDeletedIntegrationEvent(Guid id) : base(DateTime.Now)
        {
            Id = id;
        }
    }
}