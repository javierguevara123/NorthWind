
namespace NorthWind.Sales.Entities.Dtos.GetProducts
{
    public class ProductDto(
    int id,   
    string name,  
    short unitsInStock,
    decimal unitPrice)  
    {
        public int Id => id;
        public string Name => name;
        public short UnitsInStock => unitsInStock;
        public decimal UnitPrice => unitPrice;
    }
}
