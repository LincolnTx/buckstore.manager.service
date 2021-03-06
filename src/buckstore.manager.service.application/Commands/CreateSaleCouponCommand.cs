﻿using System;
using MediatR;
using buckstore.manager.service.application.Commands.CommandResponseDTOs;
using buckstore.manager.service.application.Validations;

namespace buckstore.manager.service.application.Commands
{
    public class CreateSaleCouponCommand : Command, IRequest<CreateCouponDto>
    {
        public string Coupon { get; set; }
        public int DiscountPercent { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal MinimumPrice { get; set; }
        public int CategoryClassification { get; set; }
        
        public override bool IsValid()
        {
            ValidationResult = new CreateCouponValidations().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}