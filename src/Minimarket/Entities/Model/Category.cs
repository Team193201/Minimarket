using Entities.Interface;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Category : IEntity
    {
        [Display(Name = "شناسه دسته"), Required]
        public int CategoryId { get; set; }

        [Display(Name = "نام دسته"), Required]
        public string? CategoryName { get; set; }

        [Display(Name = "شرح"), Required]
        public string? Description { get; set; }

        [Display(Name = "تصویر"), Required]
        public string? PathPicture { get; set; }
    }
}
