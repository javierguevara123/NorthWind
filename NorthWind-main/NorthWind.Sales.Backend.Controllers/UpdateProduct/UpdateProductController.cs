using Microsoft.AspNetCore.Http;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.UpdateProduct;
using NorthWind.Sales.Entities.Dtos.UpdateProduct;

namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// Controller para el endpoint de actualizar producto.
/// Expone la funcionalidad a través de HTTP PUT.
/// </summary>
public static class UpdateProductController
{
    public static WebApplication UseUpdateProductController(this WebApplication app)
    {
        app.MapPut(Endpoints.UpdateProduct, UpdateProduct) 
            .RequireAuthorization();

        return app;
    }

    private static async Task<object> UpdateProduct(int id, UpdateProductDto dto, IUpdateProductInputPort inputPort,
    IUpdateProductOutputPort presenter)
    {
        if (id != dto.ProductId)
            return Results.BadRequest(new { error = "El Id de la URL no coincide con el Id del producto" });

        await inputPort.Handle(dto);

        return new
        {
            id = presenter.ProductId,
            message = "Producto actualizado exitosamente"
        };
    }
}
