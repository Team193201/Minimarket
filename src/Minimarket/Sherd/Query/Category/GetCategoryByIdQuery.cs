using MediatR;

namespace Sheard.Query.Category
{
    public record GetCategoryByIdQuery(Guid CategoryId) : IRequest<string>;
}
