using MediatR;
using Sheard.Dto.Category;

namespace Sheard.Command.Category
{
    public record UpdateCategoryCommand(Guid CategoryId, UpdateCategoryDto Dto) : IRequest<GetCategoryDto>;
}
