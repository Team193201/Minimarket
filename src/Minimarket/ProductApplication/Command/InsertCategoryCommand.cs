using MediatR;
using ProductApplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApplication.Command
{
    public class InsertCategoryCommand: IRequest<InsertCategoryDto>
    {

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[]? Picture { get; set; }
    }
}
