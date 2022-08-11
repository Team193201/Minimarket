using MediatR;
using Sheard.Query.Product;

namespace ProductApplication.Query.Handler
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, string>
    {
        public Task<string> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            // id = > name product from req
            throw new NotImplementedException();
        }
    }
}
