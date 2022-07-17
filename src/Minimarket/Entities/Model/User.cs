using Entities.Interface;
using Microsoft.AspNetCore.Identity;

namespace Entities.Model
{
    public class User : IdentityUser<Guid>, IEntity
    {
    }
}
