using FluentValidation;
using buckstore.manager.service.application.Commands;

namespace buckstore.manager.service.application.Validations
{
    public class CreateProductValidations : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidations()
        {
            ValidateName();
            ValidateDescription();
            ValidatePrice();
            ValidateStock();
            ValidateCategory();
        }
        protected void ValidateName()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage("Campo Nome obrigatório").WithErrorCode("001")
                .MaximumLength(100)
                .WithMessage("Nome do produto pode ter no máximo 100 caracteres")
                .WithErrorCode("002");
        }

        protected void ValidateDescription()
        {
            RuleFor(product => product.Description)
                .MaximumLength(300)
                .WithMessage("A descrição do produto pode ter no máximo 300 caracteres")
                .WithErrorCode("003");
        }

        protected void ValidatePrice()
        {
            RuleFor(product => product.Price)
                .NotEmpty()
                .WithMessage("Obrigatório informar o preço do produto")
                .WithErrorCode("004");
        }

        protected void ValidateStock()
        {
            RuleFor(product => product.InitialStock)
                .NotEmpty()
                .WithMessage("Obrigatório informar o estoque inicial do produto")
                .WithErrorCode("005");
        }

        protected void ValidateCategory()
        {
            // verificar se tem como validar se o valor esta entre o meu enumeration
        }
    }
}