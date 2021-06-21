using System;
using MediatR;
using System.Threading.Tasks;
using buckstore.manager.service.api.v1.Filters.AuthorizationFilters;
using Microsoft.AspNetCore.Mvc;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.domain.Exceptions;

namespace buckstore.manager.service.api.v1.Controllers
{
    public class SaleController : BaseController
    {
        // TODO: esse controller deve ser deleatado, e passada pra a api de order
        private readonly IMediator _mediator;
        public SaleController(INotificationHandler<ExceptionNotification> notifications, IMediator mediator) 
            : base(notifications)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(nameof(UserTypes.Admin), nameof(UserTypes.Employee))]
        public async Task<IActionResult> Find([FromQuery] Guid saleId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Authorize(nameof(UserTypes.Admin))]
        public async Task<IActionResult> Create([FromBody] CreateSaleCouponCommand createCouponCommand)
        {
            var response = await _mediator.Send(createCouponCommand);

            return Response(201, response);
        }
    }
}