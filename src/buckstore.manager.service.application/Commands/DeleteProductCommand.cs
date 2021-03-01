using System;
using MediatR;
using buckstore.manager.service.application.Validations;

namespace buckstore.manager.service.application.Commands
{
    public class DeleteProductCommand : Command, IRequest<bool>
    {
        public Guid ProductCode { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new DeleteProductValidations().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}