using MediatR;
using ProductApplication.Dto;

namespace ProductApplication.Command
{
    public class InsertProductCommand : IRequest<InsertProductDto>
    {
        public string ProductName { get; set; }

        public Guid? CategoryId { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public DateTime? CreateDateTime { get; set; }
    }
}
