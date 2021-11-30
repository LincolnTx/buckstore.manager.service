using MediatR;
using System.Threading;
using System.Threading.Tasks;
using buckstore.manager.service.domain.SeedWork;
using buckstore.manager.service.domain.Exceptions;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.application.Queries.ResponseDTOs;
using buckstore.manager.service.domain.Aggregates.SalesAggregate;

namespace buckstore.manager.service.application.CommandHandlers
{
    public class EditSaleCommandHandler : CommandHandler, IRequestHandler<EditSaleCommand, CouponResponseDto>
    {
        private readonly ISaleRepository _saleRepository;

        public EditSaleCommandHandler(IUnitOfWork uow,
            IMediator bus,
            INotificationHandler<ExceptionNotification> notifications,
            ISaleRepository saleRepository) : base(uow,
            bus,
            notifications)
        {
            _saleRepository = saleRepository;
        }

        public async Task<CouponResponseDto> Handle(EditSaleCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return default;
            }
            var sale = _saleRepository.FindById(request.Id);

            if (sale == null)
            {
                await _bus.Publish(new ExceptionNotification("055", "Não foi encontrado nenhuma promoção com este Id"),
                    cancellationToken);

                return default;
            }

            sale.EditExpTime(request.ExpTime);

            if (!await Commit())
            {
                await _bus.Publish(new ExceptionNotification("056", "Erro ao edidar código de promoção"),
                    cancellationToken);

                return default;
            }

            return new CouponResponseDto
            {
                Code = sale.Code,
                Expired = false,
                Id = sale.Id,
                DiscountPercentage = sale.DiscountPercentage,
                ExpirationDate = sale.ExpirationDate,
                MinimumValue = sale.MinValue
            };
        }
    }
}
