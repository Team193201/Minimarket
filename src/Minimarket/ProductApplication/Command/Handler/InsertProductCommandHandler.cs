using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProductApplication.Command.Handler
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, List<string>>
    {
        public Task<List<string>> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            // map InsertProductCommand to entity
            //rep add product 

            // log 
            //event
            throw new NotImplementedException();
        }
    }
}
