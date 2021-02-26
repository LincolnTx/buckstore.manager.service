using System;
using buckstore.manager.service.application.Queries.ResponseDTOs;
using MediatR;

namespace buckstore.manager.service.application.Queries
{
    public class FindProductByIdQuery : IRequest<ProductResponseDto>
    {
        public Guid ProductCode { get; set; }

        public FindProductByIdQuery(Guid productCode)
        {
            ProductCode = productCode;
        }
    }
}