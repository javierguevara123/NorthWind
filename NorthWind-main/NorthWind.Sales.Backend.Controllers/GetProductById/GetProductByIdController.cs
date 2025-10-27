using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.GetProductById;
using NorthWind.Sales.Entities.Dtos.GetProductById;

namespace Microsoft.AspNetCore.Builder;

    /// <summary>
    /// Controller para el endpoint de obtener producto por ID.
    /// </summary>
    public static class GetProductByIdController
    {
        public static WebApplication UseGetProductByIdController(this WebApplication app)
        {
            app.MapGet(Endpoints.GetProductById, GetProductById)
                .RequireAuthorization();

            return app;
        }

        private static async Task<IResult> GetProductById(
            int id,
            IGetProductByIdInputPort inputPort,
            IGetProductByIdOutputPort presenter)
        {
            var dto = new GetProductByIdDto(id);

            await inputPort.Handle(dto);

            // Si no se encontró el producto, devolver 404
            if (presenter.Product == null)
            {
                return Results.NotFound(new
                {
                    error = $"Producto con Id {id} no encontrado"
                });
            }

            return Results.Ok(presenter.Product);
        }
    }
