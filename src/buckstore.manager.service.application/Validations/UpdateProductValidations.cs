using System.Linq;
using FluentValidation;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.domain.Aggregates.ProductAggregate;

namespace buckstore.manager.service.application.Validations
{
    public class UpdateProductValidations : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidations()
        {
            ValidateProductCode();
            ValidateName();
            ValidateDescription();
            ValidatePrice();
            ValidateStock();
            ValidateCategory();
        }

        private void ValidateProductCode()
        {
            RuleFor(product => product.ProductCode)
                .NotEmpty()
                .WithMessage("Código do produto deve ser informado para realizar essa alteração")
                .WithErrorCode("001");
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
            RuleFor(product => product.Stock)
                .NotEmpty()
                .WithMessage("Obrigatório informar o estoque inicial do produto")
                .WithErrorCode("005");
        }

        protected void ValidateCategory()
        {
            RuleFor(product => product.Category)
                .Must(CategoryValidate)
                .WithMessage("O id de categoria informado não esta correto.")
                .WithErrorCode("006");
        }

        private bool CategoryValidate(int category)
        {
            var availableCategories = ProductCategory.List().Select(cat => cat.Id);

            return availableCategories.Contains(category);
        }
    }
    
    
    
}