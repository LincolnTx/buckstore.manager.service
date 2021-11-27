using System;
using buckstore.manager.service.application.Commands;
using FluentValidation;

namespace buckstore.manager.service.application.Validations
{
    public class EditSaleCommandValidation : AbstractValidator<EditSaleCommand>
    {
        public EditSaleCommandValidation()
        {
            ValidateExpTime();
        }

        private void ValidateExpTime()
        {
            RuleFor(cmd => cmd.ExpTime)
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de expiração deve ser maior ou igual o dia atual");
        }
    }
}
