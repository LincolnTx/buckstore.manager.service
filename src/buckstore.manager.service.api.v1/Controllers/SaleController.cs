using System;
using MediatR;
using System.Threading.Tasks;
using buckstore.manager.service.api.v1.Filters.AuthorizationFilters;
using buckstore.manager.service.api.v1.Requests;
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
        [Authorize]
        public async Task<IActionResult> Find([FromQuery] bool onlyValid)
        {
            var request = new GetAllCouponsQuery {OnlyValid = onlyValid};

            var response = await _mediator.Send(request);

            return Response(Ok(new BaseResponseDto<AllCouponsResponseDto>(true, response)));
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
        [Authorize(nameof(UserTypes.Admin),nameof(UserTypes.Employee))]
        public async Task<IActionResult> Create([FromBody] CreateSaleCouponCommand createCouponCommand)
        {
            var response = await _mediator.Send(createCouponCommand);

            return Response(Ok(new BaseResponseDto<CreateCouponDto>(true, response)));
        }

        [HttpPatch("/manager/sale/{id}")]
        [Authorize(nameof(UserTypes.Admin), nameof(UserTypes.Employee))]
        public async Task<IActionResult> Edit(Guid id, [FromBody]EditSaleRequestDto editSale)
        {
            var response = await _mediator.Send(new EditSaleCommand(id, editSale.ExpDate));

            return Response(Ok(new BaseResponseDto<CouponResponseDto>(true, response)));
        }

        [HttpDelete("/manager/sale/{id}")]
        [Authorize(nameof(UserTypes.Admin), nameof(UserTypes.Employee))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteSaleCommand{ Id = id });

            return Response(Ok(new BaseResponseDto<bool>(true, response)));
        }
    }
}
