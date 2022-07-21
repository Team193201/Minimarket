using Entities.Interface;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Category : IEntity
    {
        [Display(Name = "شناسه دسته"), Required]
        public int CategoryID { get; set; }

        [Display(Name = "نام دسته"), Required]
        public string CategoryName { get; set; }

        [Display(Name = "شرح"), Required]
        public string Description { get; set; }

        [Display(Name = "تصویر"), Required]
        public byte[] Picture { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
