using NorthWind.Sales.Entities.Dtos.DeleteProduct;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.DeleteProduct
{
    public interface IDeleteProductInputPort
    {
        Task Handle(DeleteProductDto dto);
    }
}
