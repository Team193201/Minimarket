namespace Sheard.Dto.Product
{
    public class UpdateProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public Guid CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
    }
}
