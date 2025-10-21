﻿using NorthWind.Sales.Entities.Dtos.CreateOrder;
using NorthWind.Sales.Validators.Entities.Resources;
using NorthWind.Validation.Entities.Abstractions;
using NorthWind.Validation.Entities.Interfaces;

namespace NorthWind.Sales.Validators.Entities.CreateOrder;

internal class CreateOrderDetailDtoValidator :
AbstractModelValidator<CreateOrderDetailDto>
{
    public CreateOrderDetailDtoValidator(
   IValidationService<CreateOrderDetailDto> validator) : base(validator)
    {
        AddRuleFor(d => d.ProductId)
        .GreaterThan(0, CreateOrderMessages.ProductIdGreaterThanZero);
        AddRuleFor<int>(d => d.Quantity)
        .GreaterThan(0, CreateOrderMessages.QuantityGreaterThanZero);
        AddRuleFor(d => d.UnitPrice)
        .GreaterThan<decimal>(0,
        CreateOrderMessages.UnitPriceGreaterThanZero);
    }
}
