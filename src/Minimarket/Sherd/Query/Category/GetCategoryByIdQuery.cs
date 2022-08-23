using MediatR;

namespace Sheard.Query.Category
{
    public class GetCategoryByIdQuery : IRequest<string>
    {
        public Guid CategoryId { get; set; }
    }
}
