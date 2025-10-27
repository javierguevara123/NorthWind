using NorthWind.Sales.Backend.BusinessObjects.Interfaces.GetProductById;
using NorthWind.Sales.Entities.Dtos.GetProductById;

namespace NorthWind.Sales.Backend.Presenters.GetProductById
{
    /// <summary>
    /// Presenter para el caso de uso "Obtener Producto por ID".
    /// </summary>
    internal class GetProductByIdPresenter : IGetProductByIdOutputPort
    {
        public ProductDetailDto? Product { get; private set; }

        public Task Handle(ProductDetailDto? product)
        {
            Product = product;
            return Task.CompletedTask;
        }
    }
}
