using NorthWind.Sales.Entities.Dtos.CreateProduct;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateProduct
{
    /// <summary>
    /// InputPort para el caso de uso "Crear Producto".
    /// Define el contrato que debe implementar el Interactor.
    /// </summary>
    public interface ICreateProductInputPort
    {
        Task Handle(CreateProductDto dto);
    }
}
