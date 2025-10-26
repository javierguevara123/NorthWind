using NorthWind.Sales.Backend.BusinessObjects.Entities;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.UpdateProduct;

namespace NorthWind.Sales.Backend.Presenters.UpdateProduct
{
    /// <summary>
    /// Presenter para el caso de uso "Actualizar Producto".
    /// Formatea la respuesta que se enviará al Controller.
    /// </summary>
    internal class UpdateProductPresenter : IUpdateProductOutputPort
    {
        public int ProductId { get; private set; }
        public Product? Product { get; private set; }

        public Task Handle(Product product)
        {
            ProductId = product.Id;
            Product = product;
            return Task.CompletedTask;
        }
    }
}
