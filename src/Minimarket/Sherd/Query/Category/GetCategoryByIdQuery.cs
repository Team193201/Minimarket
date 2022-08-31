using MediatR;
using Sheard.Dto.Category;

namespace Sheard.Query.Category
{
    public record GetCategoryByIdQuery(Guid CategoryId) : IRequest<GetCategoryDto>;
}
