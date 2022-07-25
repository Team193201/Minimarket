using MediatR;

namespace Sherd.Query.Category
{
    public class GetCategoryNameQuery : IRequest<string>
    {
        public Guid CategoryId { get; set; }
    }
}
