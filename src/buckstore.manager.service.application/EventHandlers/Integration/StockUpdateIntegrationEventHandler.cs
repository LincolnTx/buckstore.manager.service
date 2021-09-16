using System.Threading;
using System.Threading.Tasks;
using buckstore.manager.service.domain.SeedWork;
using buckstore.manager.service.application.IntegrationEvents;
using buckstore.manager.service.domain.Aggregates.ProductAggregate;

namespace buckstore.manager.service.application.EventHandlers.Integration
{
    public class StockUpdateIntegrationEventHandler : EventHandler<StockUpdateIntegrationEvent>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _uow;

        public StockUpdateIntegrationEventHandler(IProductRepository productRepository, IUnitOfWork uow)
        {
            _productRepository = productRepository;
            _uow = uow;
        }

        public override async Task Handle(StockUpdateIntegrationEvent notification, CancellationToken cancellationToken)
        {
            foreach (var product in notification.Products)
            {
                var response = await _productRepository.FindById(product.ProductId);

                response.DeductStock(product.Quantity);
            }

            await _uow.Commit();
        }
    }
}
