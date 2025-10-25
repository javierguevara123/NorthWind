
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateProduct;
using NorthWind.Sales.Backend.Presenters.CreateProduct;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();
        services.AddScoped<ICreateProductOutputPort, CreateProductPresenter>();

        return services;
    }
}

