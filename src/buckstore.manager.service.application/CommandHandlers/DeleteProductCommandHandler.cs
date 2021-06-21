using MediatR;
using System.Threading;
using System.Threading.Tasks;
using buckstore.manager.service.domain.SeedWork;
using buckstore.manager.service.domain.Exceptions;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.application.IntegrationEvents;
using buckstore.manager.service.domain.Aggregates.ProductAggregate;

namespace buckstore.manager.service.application.CommandHandlers
{
    public class DeleteProductCommandHandler : CommandHandler, IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IUnitOfWork uow, IMediator bus,
            INotificationHandler<ExceptionNotification> notifications, IProductRepository productRepository)
            : base(uow, bus, notifications)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var foundProduct = await _productRepository.FindById(request.ProductCode);

            if (foundProduct == null)
            {
                await _bus.Publish(
                    new ExceptionNotification("004", "Código de produto informado não pode ser encontrado"),
                    CancellationToken.None);

                return false;
            }

            _productRepository.Delete(foundProduct);

            if (await Commit())
            {
                await _bus.Publish(new ProductDeletedIntegrationEvent(foundProduct.Id), cancellationToken);
                return true;
            }

            await _bus.Publish(
                new ExceptionNotification("004", "Código de produto informado não pode ser encontrado"),
                CancellationToken.None);

            return false;
        }
    }
}
