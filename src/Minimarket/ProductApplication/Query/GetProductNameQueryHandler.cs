using MediatR;
using Sheard.Query.Product;

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
