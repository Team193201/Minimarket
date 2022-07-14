using Entities.Interface;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Product: IEntity
    {
        [Display(Name = "کد محصول"), Required]
        public int ProductID { get; set; }

        [Display(Name = "نام محصول"), Required]
        public string ProductName { get; set; }

        [Display(Name = "دسته بندی"), Required]
        public int? CategoryID { get; set; }

        [Display(Name = "مقدار در واحد"), Required]
        public string QuantityPerUnit { get; set; }

        [Display(Name = "قیمت واحد"), Required]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "موجودی واحد"), Required]
        public short? UnitsInStock { get; set; }
    }
}
