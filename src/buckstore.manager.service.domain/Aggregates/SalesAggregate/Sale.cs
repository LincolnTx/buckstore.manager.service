using System;
using buckstore.manager.service.domain.SeedWork;

namespace buckstore.manager.service.domain.Aggregates.SalesAggregate
{
    public class Sale : Entity, IAggregateRoot
    {
        private int _discountPercentage;
        public int DiscountPercentage => _discountPercentage;
        private DateTime _expirationDate;
        public DateTime ExpirationDate => _expirationDate;
        private string _code;
        public string Code => _code;
        private decimal _minimumValue;
        public decimal MinValue => _minimumValue;

        public Sale(int discountPercentage, DateTime expirationDate, string code, decimal minimumValue)
        {
            _discountPercentage = discountPercentage;
            _expirationDate = expirationDate;
            _code = code;
            _minimumValue = minimumValue;
        }

        public bool ValidateDiscount(decimal orderValue)
        {
            return DateTime.Now <= _expirationDate && orderValue >= _minimumValue;
        }

        public string GetRejectReason(decimal orderValue)
        {
            if (DateTime.Now > _expirationDate)
            {
                return "O cupom informado está vencido!";
            }

            if (orderValue < _minimumValue)
            {
                return "O total da compra é menor do que o valor mínimo do cupom";
            }

            return string.Empty;
        }

        public void EditExpTime(DateTime expTime)
        {
            _expirationDate = expTime;
        }
    }
}
