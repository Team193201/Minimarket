namespace ProductApplication.Dto
{
    public class InsertProductDto
    {

        public string ProductName { get; set; }

        public Guid? CategoryId { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public DateTime? CreateDateTime { get; set; }
    }
}
