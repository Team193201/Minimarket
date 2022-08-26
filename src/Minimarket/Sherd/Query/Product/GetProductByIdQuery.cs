using MediatR;

namespace Sheard.Query.Product
{
    public class GetProductByIdQuery : IRequest<string>
    {
        public Guid ProductId { get; set; }
    }
}
