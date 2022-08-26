using MediatR;

namespace Sheard.Command.Product
{
    public record DeleteProductCommand (Guid ProductId) : IRequest<bool>;
}
