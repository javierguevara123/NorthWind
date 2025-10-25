
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateProduct;
using NorthWind.Sales.Entities.Dtos.CreateProduct;

namespace Microsoft.AspNetCore.Builder;

public static class CreateProductController
{
    public static WebApplication UseCreateProductController(this WebApplication app)
    {
        app.MapPost(Endpoints.CreateProduct, CreateProduct)
        .RequireAuthorization();
        return app;
    }

    public static async Task<int> CreateProduct(CreateProductDto orderDto, ICreateProductInputPort inputPort, ICreateProductOutputPort presenter)
    {
        await inputPort.Handle(orderDto);
        return presenter.ProductId;
    }
}
