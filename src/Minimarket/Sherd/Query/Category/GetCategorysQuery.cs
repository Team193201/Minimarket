using MediatR;

namespace Sheard.Query.Category
{
    public record GetCategorysQuery(int take, int skip) : IRequest<string>;
}
