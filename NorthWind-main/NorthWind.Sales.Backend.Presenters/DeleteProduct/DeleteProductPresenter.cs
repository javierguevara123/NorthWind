using NorthWind.Sales.Backend.BusinessObjects.Interfaces.DeleteProduct;

namespace NorthWind.Sales.Backend.Presenters.DeleteProduct
{
    /// <summary>
    /// Presenter para el caso de uso "Eliminar Producto".
    /// Formatea la respuesta que se enviará al Controller.
    /// </summary>
    internal class DeleteProductPresenter : IDeleteProductOutputPort
    {
        public int ProductId { get; private set; }

        public Task Handle(int productId)
        {
            ProductId = productId;
            return Task.CompletedTask;
        }
    }
}
