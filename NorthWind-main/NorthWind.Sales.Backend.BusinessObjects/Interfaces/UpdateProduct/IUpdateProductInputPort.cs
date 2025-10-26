using NorthWind.Sales.Entities.Dtos.UpdateProduct;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.UpdateProduct
{
    /// <summary>
    /// InputPort para el caso de uso "Actualizar Producto".
    /// Define el contrato que debe implementar el Interactor.
    /// </summary>
    public interface IUpdateProductInputPort
    {
        Task Handle(UpdateProductDto dto);
    }
}
