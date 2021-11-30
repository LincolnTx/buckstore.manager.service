using FluentValidation;
using buckstore.manager.service.application.Commands;

namespace buckstore.manager.service.application.Validations
{
    public class DeleteSaleCommandValidation : AbstractValidator<DeleteSaleCommand>
    {
        public DeleteSaleCommandValidation()
        {
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(product => product.Id)
                .NotEmpty()
                .WithMessage("Código do produto deve ser informado para realizar essa alteração")
                .WithErrorCode("001");
        }
    }
}
