using NorthWind.Sales.Entities.Dtos.GetProducts;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Repositories
{
    public interface IQueriesRepository
    {
        // ========== PRODUCTS ==========
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto?> GetProductById(int productId);
        Task<bool> ProductExists(int productId);

        // ⬅️ NUEVOS MÉTODOS para validación de UpdateProduct
        Task<short> GetCommittedUnits(int productId);
        Task<bool> ProductNameExists(string name, int excludeProductId);

        Task<decimal?> GetCustomerCurrentBalance(string customerId);
        Task<IEnumerable<ProductUnitsInStock>> GetProductsUnitsInStock(IEnumerable<int> productIds);

    }
}
