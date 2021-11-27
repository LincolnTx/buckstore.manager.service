using System;
using MediatR;
using System.Threading.Tasks;
using buckstore.manager.service.api.v1.Filters.AuthorizationFilters;
using buckstore.manager.service.api.v1.ResponseDtos;
using Microsoft.AspNetCore.Mvc;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.application.Commands.CommandResponseDTOs;
using buckstore.manager.service.application.Queries;
using buckstore.manager.service.application.Queries.ResponseDTOs;
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
        [Authorize(nameof(UserTypes.Admin), nameof(UserTypes.Employee))]
        public async Task<IActionResult> Find([FromQuery] Guid saleId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("/manager/validate/{code}")]
        [Authorize]
        public async Task<IActionResult> ValidateCoupon(string code)
        {
            var request = new ValidateCouponQuery(code);
            var response = await _mediator.Send(request);

            return Response(Ok(new BaseResponseDto<CouponResponseDto>(true, response)));
        }

        [HttpPost]
        [Authorize(nameof(UserTypes.Admin))]
        public async Task<IActionResult> Create([FromBody] CreateSaleCouponCommand createCouponCommand)
        {
            var response = await _mediator.Send(createCouponCommand);

            return Response(Ok(new BaseResponseDto<CreateCouponDto>(true, response)));
        }
    }
}
