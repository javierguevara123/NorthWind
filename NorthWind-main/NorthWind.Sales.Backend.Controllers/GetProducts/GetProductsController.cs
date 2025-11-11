using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.GetProducts;
using NorthWind.Sales.Entities.Dtos.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// Controller para el endpoint de obtener productos con paginación.
/// Expone la funcionalidad a través de HTTP GET.
/// </summary>
public static class GetProductsController
{
    public static WebApplication UseGetProductsController(this WebApplication app)
    {
        app.MapGet("/api/products", GetProducts)
            .WithName("GetProducts")
            .Produces<PagedResultDto<ProductDto>>(StatusCodes.Status200OK);

        return app;
    }

    private static async Task<IResult> GetProducts(
        [AsParameters] GetProductsQueryDto query,
        IGetProductsInputPort inputPort,
        IGetProductsOutputPort presenter)
    {
        await inputPort.Handle(query);

        return Results.Ok(presenter.Result);
    }
}
