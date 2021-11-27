using System;

namespace buckstore.manager.service.application.Queries.ResponseDTOs
{
    public class CouponResponseDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal MinimumValue { get; set; }
        public bool Expired { get; set; }
    }
}
