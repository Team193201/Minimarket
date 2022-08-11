using MediatR;
using Sheard.Query.Product;

namespace ProductApplication.Query.Handler
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<string>>
    {
        public Task<List<string>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            // id = > name product from req
            throw new NotImplementedException();
        }
    }
}
