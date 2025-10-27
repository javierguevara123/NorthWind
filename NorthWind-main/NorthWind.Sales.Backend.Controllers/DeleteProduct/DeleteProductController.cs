using NorthWind.Sales.Backend.BusinessObjects.Interfaces.DeleteProduct;
using NorthWind.Sales.Entities.Dtos.DeleteProduct;

namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// Controller para el endpoint de eliminar producto.
/// </summary>
public static class DeleteProductController
{
    public static WebApplication UseDeleteProductController(this WebApplication app)
    {
        app.MapDelete(Endpoints.DeleteProduct, DeleteProduct)
            .RequireAuthorization()
            .WithName("DeleteProduct");

        return app;
    }

    private static async Task<object> DeleteProduct(
        int id,
        IDeleteProductInputPort inputPort,
        IDeleteProductOutputPort presenter)
    {
        var dto = new DeleteProductDto(id);

        await inputPort.Handle(dto);

        return new
        {
            id = presenter.ProductId,
            message = "Producto eliminado exitosamente"
        };
    }
}