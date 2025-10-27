namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.DeleteProduct
{
    public interface IDeleteProductOutputPort
    {
        int ProductId { get; }
        Task Handle(int productId);
    }
}
