using MediatR;
using Sheard.Query.Product;

namespace ProductApplication.Query.Handler
{
    public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, List<string>>
    {
        public Task<List<string>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {
            // id = > name product from req
            throw new NotImplementedException();
        }
    }
}
