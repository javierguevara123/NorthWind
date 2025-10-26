using NorthWind.Sales.Backend.Repositories.Entities;

namespace NorthWind.Sales.Backend.Repositories.Interfaces
{
    public interface INorthWindSalesQueriesDataContext
    {
        IQueryable<Customer> Customers { get; }
        IQueryable<Product> Products { get; }
        IQueryable<OrderDetail> OrderDetails { get; } // ⬅️ Agregar esto

        Task<bool> AnyAsync<T>(IQueryable<T> queryable); // ⬅️ Agregar esto
        Task<int> SumAsync(IQueryable<int> queryable); // ⬅️ Agregar esto para GetCommittedUnits
        Task<ReturnType> FirstOrDefaultAync<ReturnType>(IQueryable<ReturnType> queryable);
        Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(IQueryable<ReturnType> queryable);
    }

}
