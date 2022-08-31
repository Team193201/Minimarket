using MediatR;
using Sheard.Dto.Product;

namespace Sheard.Query.Product
{
    public record GetProductsByNameQuery(string ProductName) : IRequest<List<GetProductDto>>;
}
