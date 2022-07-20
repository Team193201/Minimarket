using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProductApplication.Query.Handler
{
    public class GetProductNameQueryHandler : IRequestHandler<GetProductNameQuery, string>
    {
        public Task<string> Handle(GetProductNameQuery request, CancellationToken cancellationToken)
        {
            // id = > name product from req
            throw new NotImplementedException();
        }
    }
}
