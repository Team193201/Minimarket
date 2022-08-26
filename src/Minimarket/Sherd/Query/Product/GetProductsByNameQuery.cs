using MediatR;

namespace Sheard.Query.Product
{
    public class GetProductsByNameQuery : IRequest<List<string>>
    {
        public string ProductName { get; set; }
    }
}
