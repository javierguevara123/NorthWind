using NorthWind.Sales.Backend.BusinessObjects.Entities;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateProduct;

namespace NorthWind.Sales.Backend.Presenters.CreateProduct
{
    internal class CreateProductPresenter : ICreateProductOutputPort
    {
        public int ProductId { get; private set; }
        public Task Handle(Product addedProduct)
        {
            ProductId = addedProduct.Id;
            return Task.CompletedTask;
        }
    }
}
