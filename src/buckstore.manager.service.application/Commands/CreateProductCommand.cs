using buckstore.manager.service.application.Validations;
using MediatR;

namespace buckstore.manager.service.application.Commands
{
    public class CreateProductCommand : Command, IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InitialStock { get; set; }
        public int Category { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateProductValidations().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
