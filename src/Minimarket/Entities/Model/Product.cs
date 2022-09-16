using Entities.Interface;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Product : IEntity
    {
        [Display(Name = "کد محصول"), Required]
        public Guid? ProductId { get; set; }

        [Display(Name = "نام محصول"), Required]
        public string ProductName { get; set; }

        [Display(Name = "قیمت"), Required]
        public decimal Price { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDateTime { get; set; }

        [Display(Name = "تاریخ ویرایش")]
        public DateTime ModifiDateTime { get; set; }


        [Display(Name = "دسته بندی"), Required]
        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
