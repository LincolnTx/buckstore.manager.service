using System.Collections.Generic;
using buckstore.manager.service.application.Dtos;
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
        public List<ProductImageInformationDto> Images { get; set; }

        public CreateProductCommand(string name, string description, decimal price, int initialStock, int category, List<ProductImageInformationDto> images)
        {
            Name = name;
            Description = description;
            Price = price;
            InitialStock = initialStock;
            Category = category;
            Images = images;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateProductValidations().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
