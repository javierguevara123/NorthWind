using NorthWind.Sales.Backend.BusinessObjects.ValueObjects;
using NorthWind.Sales.Entities.Dtos.GetProducts;

namespace NorthWind.Sales.Backend.Repositories.Repositories
{
    internal class QueriesRepository(INorthWindSalesQueriesDataContext context) : IQueriesRepository
    {

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var queryable = context.Products
                .Select(p => new ProductDto(
                    p.Id,
                    p.Name,
                    p.UnitsInStock,
                    p.UnitPrice
                ));

            return await context.ToListAsync(queryable);
        }

        public async Task<bool> ProductExists(int productId)
        {
            var queryable = context.Products.Where(p => p.Id == productId);
            return await context.AnyAsync(queryable);
        }

        public async Task<short> GetCommittedUnits(int productId)
        {
            var queryable = context.OrderDetails
                .Where(od => od.ProductId == productId)
                .Select(od => (int)od.Quantity);

            var committedUnits = await context.SumAsync(queryable); // ⬅️ Llamar a través del context
            return (short)committedUnits;
        }

        public async Task<ProductDto?> GetProductById(int productId)
        {
            var queryable = context.Products
                .Where(p => p.Id == productId)
                .Select(p => new ProductDto(
                    p.Id,
                    p.Name,
                    p.UnitsInStock,
                    p.UnitPrice
                ));

            return await context.FirstOrDefaultAync(queryable);
        }

        public async Task<bool> ProductNameExists(string name, int excludeProductId)
        {
            var queryable = context.Products
                .Where(p => p.Name.ToLower() == name.ToLower() && p.Id != excludeProductId);

            return await context.AnyAsync(queryable);
        }

        public async Task<decimal?> GetCustomerCurrentBalance(
       string customerId)
        {
            var Queryable = context.Customers
            .Where(c => c.Id == customerId)
            .Select(c => new { c.CurrentBalance });
            var Result = await context.FirstOrDefaultAync(Queryable);
            return Result?.CurrentBalance;
        }
        public async Task<IEnumerable<ProductUnitsInStock>>
       GetProductsUnitsInStock(IEnumerable<int> productIds)
        {
            var Queryable = context.Products
            .Where(p => productIds.Contains(p.Id))
            .Select(p => new ProductUnitsInStock(
            p.Id, p.UnitsInStock));
            return await context.ToListAsync(Queryable);
        }
    }

}
