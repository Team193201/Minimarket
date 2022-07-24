using Entities.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product:IEntity
    {
        [Display(Name ="کد محصول"),Required]
        public Guid? ProductId { get; set; }

        [Display(Name = "نام محصول"), Required]
        public string ProductName { get; set; }

        [Display(Name = "دسته بندی"), Required]
        public Guid? CategoryId { get; set; }

        [Display(Name = "مقدار در واحد"), Required]
        public string QuantityPerUnit { get; set; }

        [Display(Name = "قیمت واحد"), Required]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "موجودی واحد"), Required]
        public short? UnitsInStock { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime? CreateDateTime { get; set; }

        [Display(Name = "تاریخ ویرایش")]
        public DateTime? ModifiDateTime { get; set; }

        public Category category { get; set; }  
    }
}
