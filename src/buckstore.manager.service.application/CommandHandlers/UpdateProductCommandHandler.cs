using MediatR;
using System.Threading;
using System.Threading.Tasks;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.application.IntegrationEvents;
using buckstore.manager.service.domain.Aggregates.ProductAggregate;
using buckstore.manager.service.domain.Exceptions;
using buckstore.manager.service.domain.SeedWork;

namespace buckstore.manager.service.application.CommandHandlers
{
    public class UpdateProductCommandHandler : CommandHandler, IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IUnitOfWork uow, IMediator bus,
            INotificationHandler<ExceptionNotification> notifications, IProductRepository productRepository)
            : base(uow, bus, notifications)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var foundProduct = await _productRepository.FindById(request.ProductCode);
            foundProduct.UpdateProduct(request.Name, request.Description, request.Price, request.Stock, request.Category);

            if (!await Commit())
            {
                await _bus.Publish(new ExceptionNotification("003", "Erro ao atualizar esse produto"),
                    CancellationToken.None);
                return false;
            }

            await _bus.Publish(new ProductUpdatedIntegrationEvent(foundProduct.Id,
                    foundProduct.Name,
                    foundProduct.Description,
                    foundProduct.Price,
                    foundProduct.Stock,
                    foundProduct.Category.Id),
                cancellationToken);
            return true;
        }
    }
}
