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
    public class CreateProductCommandHandler : CommandHandler, IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IUnitOfWork uow, IMediator bus,
            INotificationHandler<ExceptionNotification> notifications, IProductRepository productRepository)
            : base(uow, bus, notifications)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var product = new Product(request.Name.ToLowerInvariant(), request.Description, request.Price,
                request.InitialStock, request.Category);

            _productRepository.Add(product);

            if (!await Commit())
            {
                await _bus.Publish(new ExceptionNotification("001",
                    "Erro ao cadastrar produto, tente novamente mais tarde ou entre em contato com o suporte"));
                return false;
            }

            await _bus.Publish(new ProductCreatedIntegrationEvent(product.Id,
                    product.Name,
                    product.Description,
                    product.Price,
                    product.Stock,
                    product.Category.Id),
                cancellationToken);
            return true;
        }
    }
}
