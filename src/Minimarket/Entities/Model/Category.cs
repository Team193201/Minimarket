using Entities.Interface;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Category : IEntity
    {
        [Display(Name = "شناسه دسته"), Required]
        public Guid CategoryId { get; set; }

        [Display(Name = "نام دسته"), Required]
        public string CategoryName { get; set; }

        [Display(Name = "شرح"), Required]
        public string Description { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDateTime { get; set; }

        [Display(Name = "تاریخ ویرایش")]
        public DateTime ModifiDateTime { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
