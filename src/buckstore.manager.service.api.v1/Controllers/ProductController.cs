using System.Threading.Tasks;
using buckstore.manager.service.api.v1.Filters.AuthorizationFilters;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace buckstore.manager.service.api.v1.Controllers
{
    
    [Authorize(nameof(UserTypes.Admin), nameof(UserTypes.Employee))]
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

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommand updateProductCommand)
        {
            var response = await _mediator.Send(updateProductCommand);

            return Response(200, response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteProductCommand)
        {
            var response = await _mediator.Send(deleteProductCommand);

            return Response(200, response);
        }
    }
}