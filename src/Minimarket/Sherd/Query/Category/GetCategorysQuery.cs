using MediatR;

namespace Sheard.Query.Category
{
    public class GetCategorysQuery : IRequest<string>
    {
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
