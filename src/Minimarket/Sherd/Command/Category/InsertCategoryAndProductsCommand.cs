using MediatR;
using Sheard.Dto.Category;

namespace Sheard.Command.Category
{
    public record InsertCategoryAndProductsCommand(InsertCategoryAndProductsDto insertCategoryAndProductsDto) : IRequest<GetCategoryAndProductsDto>;
}
