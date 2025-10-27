using NorthWind.Sales.Entities.Dtos.GetProductById;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.GetProductById
{
    public interface IGetProductByIdInputPort
    {
        Task Handle(GetProductByIdDto dto);
    }
}
