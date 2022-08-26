using MediatR;

namespace Sheard.Query.Product
{
    public record GetProductByIdQuery (Guid ProductId) : IRequest<string>;
}
