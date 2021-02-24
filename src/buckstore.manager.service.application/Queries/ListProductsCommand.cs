using buckstore.manager.service.application.Queries.ResponseDTOs;
using buckstore.manager.service.application.Validations;
using FluentValidation.Results;
using MediatR;

namespace buckstore.manager.service.application.Queries
{
    public class ListProductsQuery : IRequest<ListProductResponse>
    {
        public int Quantity { get; set; }

        public ListProductsQuery(int quantity = 0)
        {
            Quantity = quantity > 0 ? quantity : 10;
        }
    }
}