
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateProduct;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.DeleteProduct;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.GetProductById;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.GetProducts;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.UpdateProduct;
using NorthWind.Sales.Backend.Presenters.CreateProduct;
using NorthWind.Sales.Backend.Presenters.DeleteProduct;
using NorthWind.Sales.Backend.Presenters.GetProductById;
using NorthWind.Sales.Backend.Presenters.GetProducts;
using NorthWind.Sales.Backend.Presenters.UpdateProduct;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();
        services.AddScoped<ICreateProductOutputPort, CreateProductPresenter>();
        services.AddScoped<IUpdateProductOutputPort, UpdateProductPresenter>();
        services.AddScoped<IDeleteProductOutputPort, DeleteProductPresenter>();
        services.AddScoped<IGetProductByIdOutputPort, GetProductByIdPresenter>();
        services.AddScoped<IGetProductsOutputPort, GetProductsPresenter>();

        return services;
    }
}

