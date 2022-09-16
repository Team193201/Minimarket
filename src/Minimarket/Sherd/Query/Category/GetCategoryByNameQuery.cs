using MediatR;
using Sheard.Dto.Category;

namespace Sheard.Query.Category
{
    public record GetCategoryByNameQuery(string CategoryName) : IRequest<List<GetCategoryDto>>;
}
