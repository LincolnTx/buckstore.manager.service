using System;

namespace buckstore.manager.service.application.IntegrationEvents
{
    public class ProductCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

        public ProductCreatedIntegrationEvent(Guid id, string name, string description, decimal price, int quantity, int categoryId) 
            : base(DateTime.Now)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            CategoryId = categoryId;
        }
    }
}