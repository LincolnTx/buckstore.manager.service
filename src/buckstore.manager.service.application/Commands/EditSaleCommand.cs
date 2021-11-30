using System;
using MediatR;
using buckstore.manager.service.application.Validations;
using buckstore.manager.service.application.Queries.ResponseDTOs;

namespace buckstore.manager.service.application.Commands
{
    public class EditSaleCommand : Command, IRequest<CouponResponseDto>
    {
        public Guid Id { get; set; }
        public DateTime ExpTime { get; set; }

        public EditSaleCommand(Guid id, DateTime expTime)
        {
            Id = id;
            ExpTime = expTime;
        }

        public override bool IsValid()
        {
            ValidationResult = new EditSaleCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
