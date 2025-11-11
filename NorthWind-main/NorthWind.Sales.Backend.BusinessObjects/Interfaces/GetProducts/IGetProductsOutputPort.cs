using NorthWind.Sales.Entities.Dtos.GetProducts;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.GetProducts
{
    /// <summary>
    /// OutputPort para el caso de uso "Obtener Productos".
    /// Define el contrato que debe implementar el Presenter.
    /// </summary>
    public interface IGetProductsOutputPort
    {
        PagedResultDto<ProductDto> Result { get; }
        Task Handle(PagedResultDto<ProductDto> result);
    }
}
