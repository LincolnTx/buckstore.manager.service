using System.Collections.Generic;
using System.Linq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using buckstore.manager.service.domain.SeedWork;
using buckstore.manager.service.domain.Exceptions;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.application.IntegrationEvents;
using buckstore.manager.service.domain.Aggregates.ProductAggregate;

namespace buckstore.manager.service.application.CommandHandlers
{
    public class CreateProductCommandHandler : CommandHandler, IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IUnitOfWork uow, IMediator bus,
            INotificationHandler<ExceptionNotification> notifications, IProductRepository productRepository, IMapper mapper)
            : base(uow, bus, notifications)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var productImages = _mapper.Map<IEnumerable<ProductsImage>>(request.Images);
            var product = new Product(request.Name.ToLowerInvariant(), request.Description, request.Price,
                request.InitialStock, request.Category, productImages);

            _productRepository.Add(product);

            if (!await Commit())
            {
                await _bus.Publish(new ExceptionNotification("001",
                    "Erro ao cadastrar produto, tente novamente mais tarde ou entre em contato com o suporte"));
                return false;
            }

            var images = _mapper.Map<IEnumerable<ProductsImagesCollection>>(product.Images);
            if (images.Any())
                await _productRepository.InsertProductImage(images);

            var imagesId = images.Any() ? images.Select(img => img.ImageId) : new string[1];

            await _bus.Publish(new ProductCreatedIntegrationEvent(product.Id,
                    product.Name,
                    product.Description,
                    product.Price,
                    product.Stock,
                    request.Category,
                    imagesId),
                cancellationToken);
            return true;
        }
    }
}
