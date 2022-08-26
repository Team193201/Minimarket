using MediatR;

namespace Sheard.Command.Product
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }
    }
}
