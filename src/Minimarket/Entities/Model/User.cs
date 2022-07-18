using Entities.Interface;
using Microsoft.AspNetCore.Identity;

namespace Entities.Model
{
    public class User : IdentityUser<Guid>, IEntity
    {
        public string? FName { get; set; }
        public string? LastName { get; set; }
        public string FullName { get => $"{FName} , {LastName}"; }
        public DateTime? AddTime { get; set; }
        public DateTime? ModifieTime { get; set; }
    }
}
