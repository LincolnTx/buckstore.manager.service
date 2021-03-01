using buckstore.manager.service.application.Commands;
using FluentValidation;

namespace buckstore.manager.service.application.Validations
{
    public class DeleteProductValidations : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidations()
        {
            ValidateProductCode();
        }
        private void ValidateProductCode()
        {
            RuleFor(product => product.ProductCode)
                .NotEmpty()
                .WithMessage("Código do produto deve ser informado para realizar essa alteração")
                .WithErrorCode("001");
        }
    }
}