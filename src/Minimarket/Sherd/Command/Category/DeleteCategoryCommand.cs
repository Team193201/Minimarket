using MediatR;

namespace Sheard.Command.Category
{
    public record DeleteCategoryCommand(Guid categoryId) : IRequest<Guid>;
}
