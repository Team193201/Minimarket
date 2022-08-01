using MediatR;
using Sheard.Dto.Category;

namespace Sheard.Command.Category
{
    public class InsertCategoryCommand : IRequest<InsertCategoryDto>
    {
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }
    }
}
