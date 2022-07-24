using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProductApplication.Query
{
    public class GetCategoryNameQuery : IRequest<string> 
    {
        public Guid CategoryID { get; set; }
    }
}
