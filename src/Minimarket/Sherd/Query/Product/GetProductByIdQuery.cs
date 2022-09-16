using MediatR;
using Sheard.Dto.Product;

namespace Sheard.Query.Product
{
    public record GetProductByIdQuery (Guid? ProductId) : IRequest<GetProductDto>;
}
