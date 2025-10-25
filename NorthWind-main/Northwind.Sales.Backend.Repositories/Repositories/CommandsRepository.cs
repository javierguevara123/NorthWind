
using NorthWind.Sales.Backend.BusinessObjects.Entities;
using System.Diagnostics;

namespace NorthWind.Sales.Backend.Repositories.Repositories;

internal class CommandsRepository(INorthWindSalesCommandsDataContext context) : ICommandsRepository
{
    public async Task CreateOrder(OrderAggregate order)
    {
        var sw = Stopwatch.StartNew();

        await context.AddOrderAsync(order);
        await context.AddOrderDetailsAsync(
            order.OrderDetails
            .Select(d => new Entities.OrderDetail
            {
                Order = order,
                ProductId = d.ProductId,
                Quantity = d.Quantity,
                UnitPrice = d.UnitPrice
            }).ToArray());

        sw.Stop();
        Console.WriteLine($"🕒 Tiempo CreateOrder en CommandsRepository: {sw.ElapsedMilliseconds} ms");
    }

    public async Task CreateProduct(Product product) // Este es BusinessObjects.Product
    {
        var sw = Stopwatch.StartNew();

        // Mapear de BusinessObjects.Product a Repositories.Entities.Product
        var productEntity = new Entities.Product
        {
            Name = product.Name,
            UnitPrice = product.UnitPrice,
            UnitsInStock = product.UnitsInStock,
        };

        await context.AddAsync(productEntity); // Ahora pasa la entidad correcta

        sw.Stop();
        Console.WriteLine($"🕒 Tiempo CreateProduct: {sw.ElapsedMilliseconds} ms");
    }

    public async Task SaveChanges()
    {
        var sw = Stopwatch.StartNew();

        await context.SaveChangesAsync();

        sw.Stop();
        Console.WriteLine($"🕒 Tiempo SaveChanges en CommandsRepository: {sw.ElapsedMilliseconds} ms");
    }
}


