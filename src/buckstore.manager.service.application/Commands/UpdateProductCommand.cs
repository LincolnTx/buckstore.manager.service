using System;
using buckstore.manager.service.application.Validations;
using MediatR;

namespace buckstore.manager.service.application.Commands
{
    public class UpdateProductCommand : Command, IRequest<bool>
    {
        public Guid ProductCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Category { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductValidations().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
