using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using buckstore.manager.service.api.v1.Filters.AuthorizationFilters;
using buckstore.manager.service.api.v1.Requests;
using buckstore.manager.service.api.v1.ResponseDtos;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.application.Dtos;
using buckstore.manager.service.domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequestDto request)
        {
            var uploadFiles = new List<ProductImageInformationDto>();
            if (request.Images != null)
            {

                ConvertFile(request.Images, ref uploadFiles);
            }

            var createProductCommand = new CreateProductCommand(request.Name, request.Description, request.Price,
                request.InitialStock, request.Category, uploadFiles);

            var commandResponse = await _mediator.Send(createProductCommand);

            return Response(Ok(new BaseResponseDto<bool>(true, commandResponse)));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommand updateProductCommand)
        {
            var response = await _mediator.Send(updateProductCommand);

            return Response(Ok(new BaseResponseDto<bool>(true, response)));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string productCode)
        {
            var deleteProductCommand = new DeleteProductCommand{ProductCode = Guid.Parse(productCode)};
            var response = await _mediator.Send(deleteProductCommand);

            return Response(Ok(new BaseResponseDto<bool>(true, response)));
        }

        private static void ConvertFile(IFormFileCollection files, ref List<ProductImageInformationDto> filesInfo)
        {
            foreach (var file in files)
            {
                using var ms = new MemoryStream();
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                var currentFile = new ProductImageInformationDto(fileBytes, file.ContentType);

                filesInfo.Add(currentFile);
            }
        }
    }

}
