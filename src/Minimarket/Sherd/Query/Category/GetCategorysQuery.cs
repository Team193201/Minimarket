using MediatR;
using Sheard.Dto.Category;

namespace Sheard.Query.Category
{
    public record GetCategorysQuery(int Take, int Skip) : IRequest<List<GetCategoryDto>>;
}
