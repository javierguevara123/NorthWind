
using NorthWind.Sales.Backend.Repositories.Entities;
using System.Collections.Generic;

namespace NorthWind.Sales.Backend.Repositories.Interfaces;

public interface INorthWindSalesCommandsDataContext
{

    // ========== Métodos genéricos para CRUD ==========
    Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
    Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    void Update<TEntity>(TEntity entity) where TEntity : class;
    void Remove<TEntity>(TEntity entity) where TEntity : class;

    // ========== Métodos legacy (Orders - mantener compatibilidad) ==========
    Task AddOrderAsync(Order order);
    Task AddOrderDetailsAsync(IEnumerable<OrderDetail> orderDetails);

    // ========== Save ==========
    Task SaveChangesAsync();
}