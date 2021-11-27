using MediatR;
using buckstore.manager.service.application.Queries.ResponseDTOs;

namespace buckstore.manager.service.application.Queries
{
    public class ValidateCouponQuery : IRequest<CouponResponseDto>
    {
        public string Code { get; set; }

        public ValidateCouponQuery(string code)
        {
            Code = code;
        }
    }
}
