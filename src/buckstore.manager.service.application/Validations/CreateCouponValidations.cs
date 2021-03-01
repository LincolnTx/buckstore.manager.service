using buckstore.manager.service.application.Commands;
using FluentValidation;

namespace buckstore.manager.service.application.Validations
{
    public class CreateCouponValidations : AbstractValidator<CreateSaleCouponCommand>
    {
        public CreateCouponValidations()
        {
            // criar validações
        }
    }
}