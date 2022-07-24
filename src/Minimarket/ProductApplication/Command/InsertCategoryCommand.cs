using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApplication.Command
{
    public class InsertCategoryCommand
    {
        public Guid CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[]? Picture { get; set; }
    }
}
