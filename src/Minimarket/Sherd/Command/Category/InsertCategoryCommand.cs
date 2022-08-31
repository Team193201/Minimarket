using MediatR;
using Sheard.Dto.Category;

namespace Sheard.Command.Category
{
    public record InsertCategoryCommand(InsertCategoryDto Dto) : IRequest<GetCategoryDto>;
}
