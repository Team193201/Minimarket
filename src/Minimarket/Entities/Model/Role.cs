using Entities.Interface;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model
{
    public class Role : IdentityRole<Guid>, IEntity
    {
        [Display(Name = "شرح")]
        public string? Description { get; set; }
    }
}
