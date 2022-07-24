using Entities.Model;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RoleRepository:Repository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }
        public async Task<Role> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var role = await Table.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
            return role;
        }

        public async Task<IEnumerable<Role>> GetRolesByNameAsync(string name, CancellationToken cancellationToken)
        {
            var roles = await TableNoTracking.Where(p => p.Name == name).ToListAsync(cancellationToken);

            return roles;
        }
    }
}
