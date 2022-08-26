using MediatR;

namespace Sheard.Query.Product
{
    public record GetProductsQuery(int Take, int Skip) : IRequest<List<string>>;
}
