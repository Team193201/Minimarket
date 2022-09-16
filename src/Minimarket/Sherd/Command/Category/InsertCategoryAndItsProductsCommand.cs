using MediatR;
using Sheard.Dto.Category;

namespace Sheard.Command.Category
{
    public record InsertCategoryAndItsProductsCommand(InsertCategoryAndItsProductsDto insertCategoryAndItsProductsDto) : IRequest<GetCategoryAndItsProductsDto>;
}
