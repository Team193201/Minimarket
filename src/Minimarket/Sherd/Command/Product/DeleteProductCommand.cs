using MediatR;
using Sheard.Dto.Product;

namespace Sheard.Command.Product
{
    public record DeleteProductCommand(Guid ProductId) : IRequest<Guid>;
}
