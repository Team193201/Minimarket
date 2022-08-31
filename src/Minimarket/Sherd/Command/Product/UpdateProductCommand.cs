using MediatR;
using Sheard.Dto.Product;

namespace Sheard.Command.Product
{
    public record UpdateProductCommand(Guid ProductId, UpdateProductDto Dto) : IRequest<GetProductDto>;
}
