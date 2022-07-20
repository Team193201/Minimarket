using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        [Display(Name ="کد محصول"),Required]
        public int ProductID { get; set; }

        [Display(Name = "نام محصول"), Required]
        public string ProductName { get; set; }

        [Display(Name = "دسته بندی"), Required]
        public Nullable<int> CategoryID { get; set; }

        [Display(Name = "مقدار در واحد"), Required]
        public string QuantityPerUnit { get; set; }

        [Display(Name = "قیمت واحد"), Required]
        public Nullable<decimal> UnitPrice { get; set; }

        [Display(Name = "موجودی واحد"), Required]
        public Nullable<short> UnitsInStock { get; set; }

        public Category category { get; set; }  
    }
}
