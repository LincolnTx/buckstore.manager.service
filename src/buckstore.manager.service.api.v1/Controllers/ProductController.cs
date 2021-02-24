using System.Threading.Tasks;
using buckstore.manager.service.application.Commands;
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

            return Response(200, commandResponse);
        }
    }
}