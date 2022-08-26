using MediatR;

namespace Sheard.Command.Category
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public Guid CategoryId { get; set; }
    }
}
