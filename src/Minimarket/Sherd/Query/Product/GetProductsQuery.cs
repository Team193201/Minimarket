using MediatR;
using Sheard.Dto.Product;

namespace Sheard.Query.Product
{
    public record GetProductsQuery(int Take, int Skip) : IRequest<List<GetProductDto>>;
}
