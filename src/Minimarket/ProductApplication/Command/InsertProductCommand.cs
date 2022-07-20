using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProductApplication.Command
{
    public  class InsertProductCommand:IRequest<List<string>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; } 
    }

    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
    }
}
