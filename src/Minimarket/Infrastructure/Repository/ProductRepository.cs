using Entities;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var prodct = await Table.Where(p => p.ProductId == id).FirstOrDefaultAsync(cancellationToken);
            return prodct;
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name, CancellationToken cancellationToken)
        {
            var prodcts = await TableNoTracking.Where(p => p.ProductName == name).ToListAsync(cancellationToken);

            return prodcts;
        }
    }
}
