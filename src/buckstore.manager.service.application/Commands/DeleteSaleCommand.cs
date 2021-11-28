using System;
using buckstore.manager.service.application.Validations;
using MediatR;

namespace buckstore.manager.service.application.Commands
{
    public class DeleteSaleCommand : Command, IRequest<bool>
    {
        public Guid Id { get; set; }
        public override bool IsValid()
        {
            ValidationResult = new DeleteSaleCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
