
namespace NorthWind.Sales.Backend.UseCases;

public static class DependencyContainer
{
    public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
        services.AddScoped<ICreateProductInputPort, CreateProductInteractor>();
        services.AddScoped<IUpdateProductInputPort, UpdateProductInteractor>();
        services.AddScoped<IDeleteProductInputPort, DeleteProductInteractor>();
        services.AddScoped<IGetProductByIdInputPort, GetProductByIdInteractor>();
        services.AddScoped<IGetProductsInputPort, GetProductsInteractor>();

        //CUSTOMERS
        services.AddScoped<ICreateCustomerInputPort, CreateCustomerInteractor>();
        services.AddScoped<IUpdateCustomerInputPort, UpdateCustomerInteractor>();
        services.AddScoped<IDeleteCustomerInputPort, DeleteCustomerInteractor>();
        services.AddScoped<IGetCustomerByIdInputPort, GetCustomerByIdInteractor>();
        services.AddScoped<IGetCustomersInputPort, GetCustomersInteractor>();


        services.AddModelValidator<CreateOrderDto, CreateOrderCustomerValidator>();
        services.AddModelValidator<CreateOrderDto, CreateOrderProductValidator>();
        services.AddModelValidator<CreateProductDto, CreateProductBusinessValidator>();
        services.AddModelValidator<UpdateProductDto, UpdateProductBusinessValidator>();
        services.AddModelValidator<DeleteProductDto, DeleteProductBusinessValidator>();
        services.AddModelValidator<GetProductByIdDto, GetProductByIdValidator>();

        //CUSTOMERS

        services.AddModelValidator<CreateCustomerDto, CreateCustomerBusinessValidator>();
        services.AddModelValidator<UpdateCustomerDto, UpdateCustomerBusinessValidator>();
        services.AddModelValidator<DeleteCustomerDto, DeleteCustomerBusinessValidator>();
        services.AddModelValidator<GetCustomerByIdDto, GetCustomerByIdValidator>();


        services.AddScoped<IDomainEventHandler<SpecialOrderCreatedEvent>, SendEMailWhenSpecialOrderCreatedEventHandler>();

        return services;
    }

}