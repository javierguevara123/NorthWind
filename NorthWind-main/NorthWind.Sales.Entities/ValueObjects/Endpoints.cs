
namespace NorthWind.Sales.Entities.ValueObjects;

public class Endpoints
{
    public const string CreateOrder = $"/{nameof(CreateOrder)}";
    public const string CreateProduct = $"/{nameof(CreateProduct)}";
    public const string UpdateProduct = $"/{nameof(UpdateProduct)}/{{id:int}}";
    public const string DeleteProduct = $"/{nameof(DeleteProduct)}/{{id:int}}";
    public const string GetProductById = $"/{nameof(GetProductById)}/{{id:int}}";
}
