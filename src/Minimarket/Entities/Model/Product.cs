using Entities.Interface;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Product : IEntity
    {
        [Display(Name = "کد محصول"), Required]
        public Guid ProductId { get; set; }

        [Display(Name = "نام محصول"), Required]
        public string ProductName { get; set; }

        [Display(Name = "دسته بندی"), Required]
        public Guid CategoryId { get; set; }

        [Display(Name = "مقدار در واحد"), Required]
        public string QuantityPerUnit { get; set; }

        [Display(Name = "قیمت واحد"), Required]
        public decimal UnitPrice { get; set; }

        [Display(Name = "موجودی واحد"), Required]
        public short UnitsInStock { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDateTime { get; set; }

        [Display(Name = "تاریخ ویرایش")]
        public DateTime ModifiDateTime { get; set; }

        public Category Category { get; set; }
    }
}
