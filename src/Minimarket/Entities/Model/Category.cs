using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        [Display(Name = "شناسه دسته"), Required]
        public int CategoryID { get; set; }

        [Display(Name = "نام دسته"), Required]
        public string CategoryName { get; set; }

        [Display(Name = "شرح"), Required]
        public string Description { get; set; }

        [Display(Name = "تصویر"), Required]
        public byte[] Picture { get; set; }

        public ICollection< Product> Products { get; set; }  
    }
}
