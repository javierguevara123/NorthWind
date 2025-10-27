
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

    public async Task<int> CreateProduct(Product product)
    {
        var sw = Stopwatch.StartNew();

        var productEntity = new Entities.Product
        {
            Name = product.Name,
            UnitPrice = product.UnitPrice,
            UnitsInStock = product.UnitsInStock,
        };

        await context.AddAsync(productEntity);

        sw.Stop();
        Console.WriteLine($"🕒 Tiempo CreateProduct en CommandsRepository: {sw.ElapsedMilliseconds} ms");

        return productEntity.Id;
    }

    public Task UpdateProduct(Product product)
    {
        var sw = Stopwatch.StartNew();

        var productEntity = new Entities.Product
        {
            Id = product.Id,
            Name = product.Name,
            UnitPrice = product.UnitPrice,
            UnitsInStock = product.UnitsInStock,
        };

        context.Update(productEntity);

        sw.Stop();
        Console.WriteLine($"🕒 Tiempo UpdateProduct en CommandsRepository: {sw.ElapsedMilliseconds} ms");

        return Task.CompletedTask;
    }

    public Task DeleteProduct(int productId)
    {
        var sw = Stopwatch.StartNew();

        var productEntity = new Entities.Product { Id = productId };

        context.Remove(productEntity);

        sw.Stop();
        Console.WriteLine($"🕒 Tiempo DeleteProduct en CommandsRepository: {sw.ElapsedMilliseconds} ms");

        return Task.CompletedTask;
    }

    public async Task SaveChanges()
    {
        var sw = Stopwatch.StartNew();

        await context.SaveChangesAsync();

        sw.Stop();
        Console.WriteLine($"🕒 Tiempo SaveChanges en CommandsRepository: {sw.ElapsedMilliseconds} ms");
    }
}


