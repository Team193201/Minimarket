﻿using MediatR;
using ProductApplication.Dto;

namespace ProductApplication.Command
{
    public class InsertProductCommand : IRequest<InsertProductDto>
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int? CategoryId { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public DateTime? CreateDateTime { get; set; }
    }
}
