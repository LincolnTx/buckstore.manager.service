using MediatR;
using System.Threading;
using System.Threading.Tasks;
using buckstore.manager.service.domain.SeedWork;
using buckstore.manager.service.domain.Exceptions;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.application.Commands.CommandResponseDTOs;
using buckstore.manager.service.domain.Aggregates.SalesAggregate;

namespace buckstore.manager.service.application.CommandHandlers
{
    //TODO: REMOVER ESSES COMMAND E  COMMAND HANDLER
    public class CreateSaleCouponCommandHandler : CommandHandler, IRequestHandler<CreateSaleCouponCommand, CreateCouponDto>
    {
        private readonly ISaleRepository _saleRepository;
        public CreateSaleCouponCommandHandler(IUnitOfWork uow,
            IMediator bus,
            INotificationHandler<ExceptionNotification> notifications,
            ISaleRepository saleRepository)
            : base(uow, bus, notifications)
        {
            _saleRepository = saleRepository;
        }

        public async Task<CreateCouponDto> Handle(CreateSaleCouponCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);

                return default;
            }

            var sale = new Sale(request.DiscountPercent, request.ExpirationDate, request.CouponCode.ToUpperInvariant(),
                request.MinimumPrice);

            _saleRepository.Add(sale);

            if (! await Commit())
            {
                await _bus.Publish(new ExceptionNotification("001", "Erro ao adicionar um novo cupom"),
                    cancellationToken);
                return default;
            }

            return new CreateCouponDto { CouponCode = sale.Code } ;
        }
    }
}
