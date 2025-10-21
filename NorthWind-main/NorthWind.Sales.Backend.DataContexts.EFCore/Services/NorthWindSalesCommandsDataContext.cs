
using NorthWind.Sales.Backend.DataContexts.EFCore.Guards;

namespace NorthWind.Sales.Backend.DataContexts.EFCore.Services;

internal class NorthWindSalesCommandsDataContext(IOptions<DBOptions> dbOptions)
    : NorthWindSalesContext(dbOptions), INorthWindSalesCommandsDataContext
{
    //  Agrega un objeto "Order" al contexto para ser persistido en la BD.
    public async Task AddOrderAsync(Order order) => await AddAsync(order);

    //  Agrega múltiples "OrderDetail" al contexto.
    public async Task AddOrderDetailsAsync(
        IEnumerable<Repositories.Entities.OrderDetail> orderDetails) => await AddRangeAsync(orderDetails);

    //  Persiste todos los cambios en la base de datos en una sola transacción (unidad de trabajo).
    //public async Task SaveChangesAsync() => await base.SaveChangesAsync();
    public async Task SaveChangesAsync() => await GuardDBContext.AgainstSaveChangesErrorAsync(this);
}
