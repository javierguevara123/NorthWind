
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateProduct;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.UpdateProduct;
using NorthWind.Sales.Backend.Presenters.CreateProduct;
using NorthWind.Sales.Backend.Presenters.UpdateProduct;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();
        services.AddScoped<ICreateProductOutputPort, CreateProductPresenter>();
        services.AddScoped<IUpdateProductOutputPort, UpdateProductPresenter>();

        return services;
    }
}

