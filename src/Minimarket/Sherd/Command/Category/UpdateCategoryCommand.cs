using MediatR;

namespace Sheard.Command.Category
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }
    }
}
