using MediatR;

namespace Sheard.Command.Category
{
    public record UpdateCategoryCommand(Guid categoryId , string categoryName , string description , byte[] picture) : IRequest<bool>;
}
