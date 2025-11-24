using NorthWind.Sales.Entities.Dtos.Customers.GetCustomerById;
using NorthWind.Sales.Entities.Dtos.Customers.GetCustomers;
using NorthWind.Sales.Entities.Dtos.Products.GetProducts;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Repositories
{
    public interface IQueriesRepository
    {
        // ========== PRODUCTS ==========
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto?> GetProductById(int productId);
        Task<bool> ProductExists(int productId);
        Task<PagedResultDto<ProductDto>> GetProductsPaged(GetProductsQueryDto query);  // ⬅️ NUEVO

        // Métodos adicionales (si los tienes)
        Task<short> GetCommittedUnits(int productId);
        Task<bool> ProductNameExists(string name, int excludeProductId);
        Task<bool> ProductNameExists(string name);

        // ========== CUSTOMERS & PRODUCTS (EXISTENTES) ==========
        Task<decimal?> GetCustomerCurrentBalance(string customerId);
        Task<IEnumerable<ProductUnitsInStock>> GetProductsUnitsInStock(IEnumerable<int> productIds);
        Task<bool> CustomerHasPendingOrders(string customerId);
        /// <summary>
        /// Obtiene la lista de clientes paginada.
        /// </summary>
        //Task<PagedResultDto<CustomerListDto>> GetCustomersPaged(GetCustomersQueryDto query);
        Task<CustomerPagedResultDto> GetCustomersPaged(GetCustomersQueryDto query);


        /// <summary>
        /// Obtiene un cliente por ID, retorna null si no existe.
        /// </summary>
        Task<CustomerDetailDto?> GetCustomerById(string customerId);

        /// <summary>
        /// Verifica si un cliente existe por su ID.
        /// </summary>
        Task<bool> CustomerExists(string customerId);

        /// <summary>
        /// Verifica si ya existe un cliente con el nombre especificado.
        /// </summary>
        Task<bool> CustomerNameExists(string name);

        /// <summary>
        /// Verifica si ya existe un cliente con ese nombre, excluyendo un ID (para Update).
        /// </summary>
        Task<bool> CustomerNameExists(string name, string excludeCustomerId);
    }
}
