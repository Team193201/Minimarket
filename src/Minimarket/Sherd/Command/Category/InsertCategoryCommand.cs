using MediatR;
using Sheard.Dto.Category;

namespace Sheard.Command.Category
{
    public record InsertCategoryCommand(string categoryName, string description, byte[] picture) : IRequest<InsertCategoryDto>;
}
