using System;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.domain.Exceptions;

namespace buckstore.manager.service.api.v1.Controllers
{
    public class SaleController : BaseController
    {
        private readonly IMediator _mediator;
        public SaleController(INotificationHandler<ExceptionNotification> notifications, IMediator mediator) 
            : base(notifications)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Find([FromQuery] Guid saleId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleCouponCommand createCouponCommand)
        {
            var response = await _mediator.Send(createCouponCommand);

            return Response(201, response);
        }
    }
}