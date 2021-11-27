using MediatR;
using buckstore.manager.service.application.Queries.ResponseDTOs;

namespace buckstore.manager.service.application.Queries
{
    public class GetAllCouponsQuery : IRequest<AllCouponsResponseDto>
    {
        public bool OnlyValid { get; set; }
    }
}
