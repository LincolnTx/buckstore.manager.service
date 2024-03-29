﻿using System.Linq;
using FluentValidation;
using buckstore.manager.service.application.Commands;
using buckstore.manager.service.domain.Aggregates.ProductAggregate;

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
                .WithMessage("Campo Nome obrigatório").WithErrorCode("001");
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
                .WithErrorCode("55");
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
