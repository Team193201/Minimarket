using Entities;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository:Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }
    }
}
