using NorthWind.Sales.Entities.Dtos.GetProductById;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.GetProductById
{
    public interface IGetProductByIdOutputPort
    {
        ProductDetailDto? Product { get; }
        Task Handle(ProductDetailDto? product);
    }
}
