using MediatR;

namespace Sheard.Query.Category
{
    public class GetCategoryNameQuery : IRequest<string>
    {
        public Guid CategoryId { get; set; }
    }
}
