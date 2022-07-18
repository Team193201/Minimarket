using Entities.Interface;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model
{
    public class User : IdentityUser<Guid>, IEntity
    {
        [Display(Name = "نام"), Required]
        public string? FName { get; set; }
        [Display(Name = "نام خانوادگی"), Required]
        public string? LastName { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get => $"{FName} , {LastName}"; }


        public DateTime? AddTime { get; set; }
        public DateTime? ModifieTime { get; set; }
    }
}
