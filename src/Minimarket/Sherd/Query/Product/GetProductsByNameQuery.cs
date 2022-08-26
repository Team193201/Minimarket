using MediatR;

namespace Sheard.Query.Product
{
    public record GetProductsByNameQuery(string ProductName) : IRequest<List<string>>;
}
