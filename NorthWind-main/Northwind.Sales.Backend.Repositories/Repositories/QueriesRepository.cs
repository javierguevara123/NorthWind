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

        // ========== PRODUCTS CON PAGINACIÓN ==========

        public async Task<PagedResultDto<ProductDto>> GetProductsPaged(GetProductsQueryDto query)
        {
            // 1. Crear query base
            var queryable = context.Products.AsQueryable();

            // 2. Aplicar filtros
            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                var searchTerm = query.SearchTerm.ToLower();
                queryable = queryable.Where(p => p.Name.ToLower().Contains(searchTerm));
            }

            if (query.MinPrice.HasValue)
                queryable = queryable.Where(p => p.UnitPrice >= query.MinPrice.Value);

            if (query.MaxPrice.HasValue)
                queryable = queryable.Where(p => p.UnitPrice <= query.MaxPrice.Value);

            if (query.IsLowStock.HasValue && query.IsLowStock.Value)
                queryable = queryable.Where(p => p.UnitsInStock < 10);

            // 3. Obtener total de registros (USANDO MÉTODO DEL CONTEXTO)
            var totalCount = await context.CountAsync(queryable);  // ⬅️ CORREGIDO

            // 4. Aplicar ordenamiento
            queryable = ApplyOrdering(queryable, query.OrderBy, query.OrderDescending);

            // 5. Aplicar paginación y proyección
            var pagedQuery = queryable
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(p => new ProductDto(
                    p.Id,
                    p.Name,
                    p.UnitsInStock,
                    p.UnitPrice
                ));

            // 6. Ejecutar query (USANDO MÉTODO DEL CONTEXTO)
            var items = await context.ToListAsync(pagedQuery);  // ⬅️ YA ESTABA BIEN

            // 7. Retornar resultado paginado
            return new PagedResultDto<ProductDto>
            {
                Items = items,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                TotalCount = totalCount
            };
        }

        private IQueryable<Entities.Product> ApplyOrdering(
            IQueryable<Entities.Product> queryable,
            string? orderBy,
            bool descending)
        {
            return orderBy?.ToLower() switch
            {
                "price" => descending
                    ? queryable.OrderByDescending(p => p.UnitPrice)
                    : queryable.OrderBy(p => p.UnitPrice),

                "stock" => descending
                    ? queryable.OrderByDescending(p => p.UnitsInStock)
                    : queryable.OrderBy(p => p.UnitsInStock),

                "name" or _ => descending
                    ? queryable.OrderByDescending(p => p.Name)
                    : queryable.OrderBy(p => p.Name)
            };
        }

        public async Task<bool> ProductNameExists(string name)
        {
            var queryable = context.Products
                .Where(p => p.Name.ToLower() == name.ToLower());

            return await context.AnyAsync(queryable);
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
