using System.Collections.Generic;

namespace buckstore.manager.service.application.Queries.ResponseDTOs
{
    public class AllCouponsResponseDto
    {
        public IEnumerable<CouponResponseDto> Coupons { get; set; }

        public AllCouponsResponseDto(IEnumerable<CouponResponseDto> coupons)
        {
            Coupons = coupons;
        }
    }
}
