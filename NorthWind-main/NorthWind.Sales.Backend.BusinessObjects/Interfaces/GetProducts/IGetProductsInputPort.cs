using NorthWind.Sales.Entities.Dtos.GetProducts;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.GetProducts;

/// <summary>
/// InputPort para el caso de uso "Obtener Productos".
/// Define el contrato que debe implementar el Interactor.
/// </summary>
public interface IGetProductsInputPort
{
    Task Handle(GetProductsQueryDto query);
}
