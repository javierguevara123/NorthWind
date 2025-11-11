using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.Entities.Dtos.CreateOrder;
using NorthWind.Sales.Entities.Dtos.CreateProduct;
using NorthWind.Sales.Entities.Dtos.UpdateProduct;
using NorthWind.Sales.Validators.Entities.CreateOrder;
using NorthWind.Sales.Validators.Entities.CreateProduct;
using NorthWind.Sales.Validators.Entities.UpdateProduct;
using NorthWind.Validation.Entities;

namespace NorthWind.Sales.Validators.Entities;

public static class DependencyContainer
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddModelValidator<CreateOrderDto, CreateOrderDtoValidator>();
        services.AddModelValidator<CreateOrderDetailDto, CreateOrderDetailDtoValidator>();
        services.AddModelValidator<UpdateProductDto, UpdateProductDtoValidator>();
        services.AddModelValidator<CreateProductDto, CreateProductDtoValidator>();
        return services;
    }
}
