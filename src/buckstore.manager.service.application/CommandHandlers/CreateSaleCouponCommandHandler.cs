using MediatR;
using System.Threading;
using System.Threading.Tasks;
using buckstore.manager.service.domain.SeedWork;
using buckstore.manager.service.domain.Exceptions;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.application.Commands.CommandResponseDTOs;

namespace buckstore.manager.service.application.CommandHandlers
{
    //TODO: REMOVER ESSES COMMAND E  COMMAND HANDLER
    public class CreateSaleCouponCommandHandler : CommandHandler, IRequestHandler<CreateSaleCouponCommand, CreateCouponDto>
    {
        public CreateSaleCouponCommandHandler(IUnitOfWork uow, IMediator bus, INotificationHandler<ExceptionNotification> notifications)
            : base(uow, bus, notifications)
        {
        }

        public Task<CreateCouponDto> Handle(CreateSaleCouponCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
