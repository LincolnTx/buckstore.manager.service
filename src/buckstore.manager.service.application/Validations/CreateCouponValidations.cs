using System;
using FluentValidation;
using buckstore.manager.service.application.Commands;

namespace buckstore.manager.service.application.Validations
{
    public class CreateCouponValidations : AbstractValidator<CreateSaleCouponCommand>
    {
        public CreateCouponValidations()
        {
            ValidateCode();
            ValidateDiscountPercent();
            ValidateExpiration();
        }

        private void ValidateCode()
        {
            RuleFor(cmd => cmd.CouponCode)
                .NotEmpty()
                .WithMessage("O códido do cupom deve ser informado")
                .WithErrorCode("001");
        }

        private void ValidateDiscountPercent()
        {
            RuleFor(cmd => cmd.DiscountPercent)
                .NotEmpty()
                .WithMessage("A porcentegem do desconto deve ser informado")
                .WithErrorCode("002");
        }

        private void ValidateExpiration()
        {
            RuleFor(cmd => cmd.ExpirationDate)
                .NotEmpty()
                .GreaterThan(DateTime.Now)
                .WithMessage("A data de expiração deve ser informado e deve ser maior que a data atual")
                .WithErrorCode("003");
        }
    }
}
