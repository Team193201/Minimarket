using MediatR;
using Sheard.Dto.Product;

namespace Sheard.Command.Product
{
    public record InsertProductCommand(InsertProductDto Dto) : IRequest<GetProductDto>;
}
