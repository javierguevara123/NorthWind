namespace NorthWind.Sales.Entities.Dtos.GetProductById
{
    public record ProductDetailDto(
    int Id,
    string Name,
    short UnitsInStock,
    decimal UnitPrice
);
}
