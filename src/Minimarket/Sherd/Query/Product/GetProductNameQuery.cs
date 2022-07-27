using MediatR;

namespace Sherd.Query.Product
{
    public class GetProductNameQuery : IRequest<string>
    {
        public Guid ProductId { get; set; }
    }
}
