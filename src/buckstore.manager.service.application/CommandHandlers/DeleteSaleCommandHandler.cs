using MediatR;
using System.Threading;
using System.Threading.Tasks;
using buckstore.manager.service.domain.SeedWork;
using buckstore.manager.service.domain.Exceptions;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.domain.Aggregates.SalesAggregate;

namespace buckstore.manager.service.application.CommandHandlers
{
    public class DeleteSaleCommandHandler : CommandHandler, IRequestHandler<DeleteSaleCommand, bool>
    {
        private readonly ISaleRepository _saleRepository;

        public DeleteSaleCommandHandler(IUnitOfWork uow,
            IMediator bus,
            INotificationHandler<ExceptionNotification> notifications,
            ISaleRepository saleRepository) : base(uow,
            bus,
            notifications)
        {
            _saleRepository = saleRepository;
        }

        public async Task<bool> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var sale = _saleRepository.FindById(request.Id);

            if (sale == null)
            {
                await _bus.Publish(new ExceptionNotification("056", "Não foi encontrado nenhuma promoção com este Id"),
                    cancellationToken);

                return false;
            }

            _saleRepository.Delete(sale);

            if (await Commit())
                return true;

            await _bus.Publish(new ExceptionNotification("056", "Não foi possível realizar a remoção desse cupom"),
                cancellationToken);

            return false;

        }
    }
}
