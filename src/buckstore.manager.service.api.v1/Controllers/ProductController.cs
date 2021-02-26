using System;
using System.Threading.Tasks;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.application.Queries;
using buckstore.manager.service.domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace buckstore.manager.service.api.v1.Controllers
{
    
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        
        public ProductController(INotificationHandler<ExceptionNotification> notifications, IMediator mediator) : base(notifications)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand createProductCommand)
        {
            var commandResponse = await _mediator.Send(createProductCommand);

            return Response(201, commandResponse);
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListProducts([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var queryResponse = await _mediator.Send(new ListProductsQuery(pageNumber, pageSize));

            return Response(200, queryResponse);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid productCode)
        {
            var response = await _mediator.Send(new FindProductByIdQuery(productCode));

            return Response(200, response);
        }
    }
}