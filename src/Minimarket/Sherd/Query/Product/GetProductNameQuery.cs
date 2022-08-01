using MediatR;

namespace Sheard.Query.Product
{
    public class GetProductNameQuery : IRequest<string>
    {
        public Guid ProductId { get; set; }
    }
}
