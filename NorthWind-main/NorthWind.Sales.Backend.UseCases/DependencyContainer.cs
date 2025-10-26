using Microsoft.Extensions.DependencyInjection;
using NorthWind.Events.Entities.Interfaces;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateProduct;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.UpdateProduct;
using NorthWind.Sales.Backend.UseCases.CreateOrder;
using NorthWind.Sales.Backend.UseCases.CreateProduct;
using NorthWind.Sales.Backend.UseCases.UpdateProduct;
using NorthWind.Sales.Entities.Dtos.CreateOrder;
using NorthWind.Sales.Entities.Dtos.UpdateProduct;
using NorthWind.Validation.Entities;

namespace NorthWind.Sales.Backend.UseCases;

public static class DependencyContainer
{
    public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
        services.AddScoped<ICreateProductInputPort, CreateProductInteractor>(); 
        services.AddScoped<IUpdateProductInputPort, UpdateProductInteractor>();

        services.AddModelValidator<CreateOrderDto, CreateOrderCustomerValidator>();
        services.AddModelValidator<CreateOrderDto, CreateOrderProductValidator>();
        services.AddModelValidator<UpdateProductDto, UpdateProductBusinessValidator>();

        services.AddScoped<IDomainEventHandler<SpecialOrderCreatedEvent>, SendEMailWhenSpecialOrderCreatedEventHandler>();

        return services;
    }

}