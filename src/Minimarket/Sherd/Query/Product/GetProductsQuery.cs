using MediatR;

namespace Sheard.Query.Product
{
    public class GetProductsQuery : IRequest<List<string>>
    {
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
